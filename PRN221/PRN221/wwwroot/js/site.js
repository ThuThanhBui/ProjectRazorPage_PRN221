﻿// Lấy id của button được chọn từ localStorage nếu có
$(() => {
    var connection = new signalR.HubConnectionBuilder()
        .configureLogging(signalR.LogLevel.Debug)
        .withUrl("/signalRServer", {
            skipNegotiation: true,
            transport: signalR.HttpTransportType.WebSockets
        }).build();

    connection.start().then(function () {
        console.log('Connected!');
    }).catch(function (err) {
        return console.error(err.toString());
    });

    connection.on("LoadProducts", function () {
        LoadProdData();
    });

    LoadProdData();

    function LoadProdData() {
        var tr = '';
        $.ajax({
            url: '/OrderManagement/?handler=SignalR',
            dataType: 'json',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `
                    <tr>
                        <td>${v.User.Email}</td>
                        <td style="width:25%">${v.Description}</td>
                        <td>
                            ${v.Voucher != null ? v.Voucher.VoucherName : '<p>No voucher</p>'}
                        </td>
                        <td>${v.TotalPrice}$</td>
                        <td>${v.CreatedDate ? new Date(v.CreatedDate).toLocaleDateString() : ''}</td>
                        <td>${v.LastUpdatedDate ? new Date(v.LastUpdatedDate).toLocaleDateString() : ''}</td>
                        <td>
                            ${v.Status == "Completed" ? '<p class="btn btn-success">' + v.Status + '</p>' :
                            v.Status == "Approved" ? '<p class="btn btn-primary">' + v.Status + '</p>' :
                                v.Status == "Waiting" || v.Status == "Delivering" ? '<p class="btn btn-warning">' + v.Status + '</p>' :
                                    v.Status == "Canceled" ? '<p class="btn btn-danger">' + v.Status + '</p>' : ''}
                        </td>
                        <td>
                            <a href="/OrderManagement/Edit?id=${v.Id}">Edit</a>
                        </td>
                    </tr>
                    `;
                });
                console.log(tr);
                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.error("AJAX Error: ", error);
                console.error("Status: ", error.status);
                console.error("Status Text: ", error.statusText);
                console.error("Response Text: ", error.responseText);
            }
        });
    }
});



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


document.addEventListener("DOMContentLoaded", function () {
    var base64Image = "@Model.Product.Image";
    if (base64Image) {
        fetch("data:image;base64," + base64Image)
            .then(res => res.blob())
            .then(blob => {
                var file = new File([blob], "productImage.jpg", { type: blob.type });
                var dataTransfer = new DataTransfer();
                dataTransfer.items.add(file);
                document.getElementById("fileInput").files = dataTransfer.files;
            });
    }
});