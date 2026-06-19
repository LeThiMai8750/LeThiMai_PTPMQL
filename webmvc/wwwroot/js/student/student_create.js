// ===============================
// Open Create Modal
// ===============================
$(document).on('click', '#btnAddStudent', function () {
    //debugger;
    $.ajax({

        url: '/Student/Create',

        type: 'GET',

        success: function (response) {

            $('#modalContainer').html(response);

            // Bootstrap 5
            const modal = new bootstrap.Modal(
                document.getElementById('studentModal')
            );

            modal.show();

        },

        error: function () {

            alert('Cannot load create form');

        }

    });

});


// ===============================
// Submit Create Form
// ===============================
$(document).on('submit', '#studentForm', function (e) {

    e.preventDefault();

    let form = $(this);

    $.ajax({

        url: '/Student/Create',

        type: 'POST',

        data: form.serialize(),

        success: function (response) {


            if (response.success || response.Success) {
                // 1. CHÍ MẠNG: Bắt nút Lưu nhả focus ra ngay lập tức
                if (document.activeElement) {
                    document.activeElement.blur();
                }

                // 2. Tiến hành đóng modal bằng Bootstrap API
                const modalElement = document.getElementById('studentModal');
                const modal = bootstrap.Modal.getInstance(modalElement);
                if (modal) modal.hide();

                // 3. Gọi hàm load lại bảng dữ liệu (Lúc này hệ thống đã hết đơ, bảng sẽ chạy);

                // Reload table
                loadStudentTable(currentPage);


            }
            else {

                // Nếu validate lỗi
                $('#modalContainer').html(response);

                const modal = new bootstrap.Modal(
                    document.getElementById('studentModal')
                );

                modal.show();

            }

        },

        error: function () {

            alert('Create failed');

        }

    });

});