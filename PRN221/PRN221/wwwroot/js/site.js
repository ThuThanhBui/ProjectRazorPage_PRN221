// Lấy id của button được chọn từ localStorage nếu có
var chosenBrand = localStorage.getItem('chosenBrand');

// Nếu có id của button được chọn, cuộn đến vị trí của button đó khi trang được load lại
if (chosenBrand) {
    var button = document.getElementById(chosenBrand);
    if (button) {
        button.scrollIntoView();
    }
}

// Lắng nghe sự kiện click trên các button để lưu id của button được chọn vào localStorage
var buttons = document.querySelectorAll('.btn-brand');
buttons.forEach(function (button) {
    button.addEventListener('click', function () {
        localStorage.setItem('chosenBrand', button.id);
    });
});