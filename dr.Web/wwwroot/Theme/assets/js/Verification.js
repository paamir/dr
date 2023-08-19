function setFormMessage(formElement, type, message) {
    const messageElement = formElement.querySelector(".form__massage");

    messageElement.textContent = message;
    messageElement.classList.remove("form__message--success", "form__message--error");
    messageElement.classList.add("alert", `alert-${type}`);
}

function setInputError(inputElement, message) {
    inputElement.classList.add("form__input--error");
    inputElement.parentElement.querySelector(".form__input-error-message").textContent = message;
}

function clearInputError(inputElement) {
    inputElement.classList.remove("form__input--error");
    inputElement.parentElement.querySelector(".form__input-error-message").textContent = "";
}

function clearDangerAlert() {
    const alerts = document.querySelectorAll(".alert-danger");
    alerts.forEach(x => {
        x.classList.remove("alert", "alert-danger");
        x.textContent = "";
    });
}
document.addEventListener("DOMContentLoaded", () => {
    var sendVerificationCodeForm = document.getElementById("SendVerificationCode");
    var verifyCodeForm = document.getElementById("verifyCodeForm");
    sendVerificationCodeForm.addEventListener("submit", e => {
        debugger;
        e.preventDefault();
        var sendVerificationCodeFormData = $(sendVerificationCodeForm).serialize(); 
        $.ajax({
            type: "Post",
            url: $(sendVerificationCodeForm).attr("action"),
            data: sendVerificationCodeFormData,
            async: false
        }).done(function (response) {
            if (response.isSuccedded) {
                sendVerificationCodeForm.classList.add("hideForm");
                verifyCodeForm.classList.remove("hideForm");
                setFormMessage(verifyCodeForm, "success", response.message);
            } else {
                sendVerificationCodeForm.classList.remove("hideForm");
                verifyCodeForm.classList.add("hideForm");
                setFormMessage(sendVerificationCodeForm, "danger", response.message);
            }
        }).fail(function (response) {
            sendVerificationCodeForm.classList.remove("hideForm");
            verifyCodeForm.classList.add("hideForm");
            setFormMessage(sendVerificationCodeForm, "danger", response.responseText);
        });
    });

});



//function checkInputs() {
//    if (document.getElementById("PasswordReCheck").value === document.getElementById("Password").value) {
//        return true;
//    } else {
//        debugger;
//        setFormMessage(document.getElementById("registerForm"),
//            "danger",
//            "رمز عبور و تکرار رمز عبور با هم مطابقت ندارند");
//        return false;
//    }
//}



//    document.querySelectorAll(".form_input").forEach(inputElement => {
//        inputElement.addEventListener("input", e => {
//            if (e.target.id === "PasswordReCheck" || e.target.id === "Password") {
//                if (document.getElementById("PasswordReCheck").value !== document.getElementById("Password").value) {
//                    setInputError(document.getElementById("PasswordReCheck"), "رمز عبور و تکرار رمز عبور با هم مطابقت ندارند");
//                    setInputError(document.getElementById("Password"), "رمز عبور و تکرار رمز عبور با هم مطابقت ندارند");
//                } else {
//                    clearInputError(document.getElementById("PasswordReCheck"));
//                    clearInputError(document.getElementById("Password"));
//                    clearDangerAlert();
//                }
//            }
//        });

//    });