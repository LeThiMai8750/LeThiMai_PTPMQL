// Khai báo các biến toàn cục quản lý phân trang Student (nếu chưa khai báo ở đầu file)
let currentPage = 1;
let currentPageSize = 10; // Kích thước trang mặc định (Ví dụ: 10 sinh viên/trang)
const STUDENT_API = "/Student"; // Đường dẫn gốc tới StudentController

$(document).ready(function () {
    // Load dữ liệu lần đầu
    loadStudentTable(1);
});


// // ==========================================
// // 1. Load danh sách sinh viên bằng AJAX
// // ==========================================
// function loadStudentTable(page = 1) {
//     currentPage = page;
  
//     // crl K + ctr c
//     $.ajax({
//         url: `${STUDENT_API}/GetStudentTable`, // Gọi đúng Action phân trang ở StudentController
//         type: 'GET',
//         data: {
//             page: currentPage,
//             pageSize: currentPageSize // Gửi cả số trang và số lượng dòng/trang lên Server
//         },
//                 beforeSend: function () {
//             // Hiển thị hiệu ứng Spinner quay trong lúc chờ nạp danh sách sinh viên
//             $('#studentTableContainer').html(`
//                 <div class="text-center p-5">
//                     <div class="spinner-border text-primary" role="status"></div>
//                     <div class="mt-2 text-muted">
//                         Đang tải danh sách sinh viên...
//                     </div>
//                 </div>
//             `);
//         },
//         success: function (response) {
//             // Ghi đè HTML Partial View trả về vào vùng chứa bảng sinh viên
//             $('#studentTableContainer').html(response);
//         },
//         error: function () {
//             // Hiển thị thông báo lỗi nếu không kết nối được Server
//             $('#studentTableContainer').html(`
//                 <div class="alert alert-danger text-center font-weight-bold">
//                     Có lỗi xảy ra khi tải danh sách sinh viên. Vui lòng thử lại!
//                 </div>
//             `);
//         }
//     });
// }
// //  debugger;
// // ==========================================
// // 2. Sự kiện Click chuyển số trang (Pagination)
// // ==========================================
// $(document).on('click', '.pagination-link', function (e) {
//     e.preventDefault(); // Chặn hành vi nhảy link mặc định của thẻ <a>
    
//     // Nếu nút bấm (hoặc thẻ li cha) đang bị khóa (.disabled) hoặc đang active thì không chạy lại
//     if ($(this).parent().hasClass('disabled') || $(this).parent().hasClass('active')) {
//         return;
//     }
    
//     let page = $(this).data('page'); // Móc số trang từ thuộc tính data-page ra
//     loadStudentTable(page); // Gọi hàm tải trang dữ liệu mới
// });

// // ==========================================
// // 3. Sự kiện Thay đổi số lượng sinh viên/trang
// // ==========================================
// $(document).on('change', '#pageSizeSelect', function () {
//     currentPageSize = $(this).val(); // Lấy giá trị lựa chọn mới (Ví dụ: 10, 20, 50)
    
//     // Khi đổi số lượng bản ghi hiển thị, bắt buộc phải Reset về trang 1 ban đầu
//     currentPage = 1; 
//     loadStudentTable(currentPage);
// });