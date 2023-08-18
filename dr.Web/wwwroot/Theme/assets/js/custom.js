const cookieName = "cart-items";

function toMoney(money) {
    //the ja-jp is like rial me do it for number language (for the persian number 'fa-ir')
    var formater = new Intl.NumberFormat('ja-jp');
    return formater.format(money);
}
function AddToCart(id, name, price, picture, slug) {
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }

    let count = parseInt($("#ProductCount").val());
    const maxCount = parseInt($("#ProductCount").attr("max"));
    if (count > maxCount) {
        count = maxCount;
    }else if(count < 1) {
        count = 1;
    }
    let currentProduct = products.find(x => x.id === id);
    if (currentProduct !== undefined) {
        if (count + parseInt(currentProduct.count) > maxCount) {
            alert("امکان سفارش بیشتر از حداکثر قابل سفارش وجود ندارد برای سفارش بیشتر از این تعداد با شرکت تماس بگیرید");
            currentProduct.count = maxCount;
        } else {
            currentProduct.count = count + parseInt(currentProduct.count);
        }
    } else {
        const product = {
            id,
            count,
            name,
            UnitPrice: price,
            picture,
            slug: slug
        }
        products.push(product);
    }
    $.cookie(cookieName, JSON.stringify(products), { expires: 10, path: "/"});
    UpdateCartItems();
}

function UpdateCartItems() {
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }
    if (products.length != 0) {
        $('#CartItemsCount').text(products.length);
    }else {
        $('#CartItemsCount').text('')
    }
    $("#CartItems").html('');
    products.forEach(x => {
        const product = `<div class="single-cart-item">
                            <a href="javascript:void(0)" class="remove-icon">
                                <i class="ion-android-close" onclick="RemoveFromCart(${x.id})"></i>
                            </a>
                            <div class="image">
                                <a href="/Product/${x.slug}">
                                    <img src="/Pictures/${x.picture}"
                                         class="img-fluid">
                                </a>
                            </div>
                            <div class="content">
                                <p class="product-title">
                                    <a href="/Product/${x.slug}">نام محصول : ${x.name}</a>
                                </p>
                                <p class="count">تعداد : ${x.count}</p>
                                <p  class="count">قیمت واحد : ${toMoney(x.UnitPrice)}</p>
                            </div>
                        </div>`;
        $('#CartItems').append(product);
    });

    calculateBill(products);
    $.cookie(cookieName, JSON.stringify(products), { expires: 10, path: "/"});
}

function calculateBill(products) {
    let total = 0;
    let discountTotal = 0;
    let totalWithDiscount = 0;
    for (var i = 0; i < products.length; i++) {
        var settings = {
            "url": `https://localhost:5001/api/DiscountApi/${products[i].id}`,
            "method": "GET",
            "async":false
        };

        $.ajax(settings).done(function (response) {
            discountTotal += parseInt(response)* parseInt(products[i].count);
        });
        total += products[i].UnitPrice * products[i].count;
    }
    totalWithDiscount = total - discountTotal
    $("#totalItemsPrice").text(toMoney(total));
    $("#totalDiscountPrice").text(toMoney(discountTotal));
    $("#payAmount").text(toMoney(totalWithDiscount));
}
function RemoveFromCart(id) {
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }
    let itemToRemove = products.findIndex(x => x.id === id);
    products.splice(itemToRemove, 1);

    $.cookie(cookieName, JSON.stringify(products), { expires: 10, path: "/"});
    UpdateCartItems();
}


function reformAutomaticallyProductCount(id, count) {
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }
    let itemToReForm = products.findIndex(x => x.id === id);
    if (itemToReForm !== -1) {
        if (parseInt(count) === 0) {
            products.splice(itemToReForm, 1)
        } else {
            products[itemToReForm].count = count;
        }
    } else {
        window.location.reload();
        products = [];
        alert("محصول مورد نظر پیدا نشد");
    }
    $.cookie(cookieName, JSON.stringify(products), { expires: 10, path: "/" });
    UpdateCartItems();
    window.location.reload();
}


function changeProductCount(id, totalPriceId, count) {
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }
    let Count = parseInt(count);
    var productIndex = products.findIndex(x => x.id === id);

    const inputTag = $(`#product-${id}`);
    const maxOrder = parseInt(inputTag.attr("max"));
    const userOrder = parseInt(inputTag.attr("value"));
    const x = document.getElementById(`product-alert-${id}`);
    if (maxOrder < Count) {
        if (x === null) {
            $(".page-wrapper").prepend(
                `                        <div id="product-alert-${id
                }" class="alert alert-warning d-flex justify-content-between">
                            <span class="p-2"><i class="fa fa-warning"></i> محصول <strong>${products[productIndex].name
                }</strong> گذاشتن حد اکثر قابل سفارش(${maxOrder})</span>
                            <div class="btn btn-success btn-reformAutomatically-ProductCount p-1" onclick="reformAutomaticallyProductCount(${
                id}, ${maxOrder})">تصحیح خودکار تعداد</div>
                        </div>`);
        }
        alert(
            "امکان سفارش بیشتر از حداکثر قابل سفارش وجود ندارد برای سفراش گذاری حداکثر دکمه سبز رنگ را بزنید ، برای سفراش گذاری بیشتر با مدیریت تماس بگیرید");
    } else {
        if (x !== null) {
            x.remove();
        }
    }
    products[productIndex].count = Count;

    let newTotalPrice = toMoney(Count * products[productIndex].UnitPrice);
    $(`#${totalPriceId}`).text(newTotalPrice + ' تومان');

    $.cookie(cookieName, JSON.stringify(products), { expires: 10, path: "/" });
    UpdateCartItems();
}
