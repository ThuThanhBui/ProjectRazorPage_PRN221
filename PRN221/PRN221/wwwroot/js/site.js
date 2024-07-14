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
//----------------------------------------------------------
document.getElementById('fileInput').addEventListener('change', function (event) {
    const file = event.target.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            const img = document.createElement('img');
            img.src = e.target.result;
            const imageDisplay = document.getElementById('imageDisplay');
            imageDisplay.innerHTML = '';
            imageDisplay.appendChild(img);
        }
        reader.readAsDataURL(file);
    }
});
