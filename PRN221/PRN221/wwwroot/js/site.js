// Lấy id của button được chọn từ localStorage nếu có
document.addEventListener("DOMContentLoaded", function () {
    var chosenBrand = localStorage.getItem('chosenBrand');
    if (chosenBrand) {
        var button = document.getElementById(chosenBrand);
        if (button) {
            button.scrollIntoView();
        }
    }
});


// Lắng nghe sự kiện click trên các button để lưu id của button được chọn vào localStorage
var buttons = document.querySelectorAll('.btn-brand');
buttons.forEach(function (button) {
    button.addEventListener('click', function () {
        localStorage.setItem('chosenBrand', button.id);
    });
});
//----------------------------------------------------------
//document.getElementById('fileInput').addEventListener('change', function (event) {
//    const file = event.target.files[0];
//    if (file) {
//        const reader = new FileReader();
//        reader.onload = function (e) {
//            const img = document.createElement('img');
//            img.src = e.target.result;
//            const imageDisplay = document.getElementById('imageDisplay');
//            imageDisplay.innerHTML = '';
//            imageDisplay.appendChild(img);
//        }
//        reader.readAsDataURL(file);
//    }
//});
document.getElementById('fileInput').addEventListener('change', function (event) {
    const file = event.target.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            const img = document.createElement('img');
            img.src = e.target.result;
            img.style.maxWidth = '100%';
            img.style.height = 'auto';
            const imageDisplay = document.getElementById('imageDisplay');
            imageDisplay.innerHTML = '';
            imageDisplay.appendChild(img);
        }
        reader.readAsDataURL(file);
    }
});
