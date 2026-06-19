````md
# Cấu trúc thư mục MVC (.NET)

```
webmvc
├── Controllers
├── Models
├── obj
├── Properties
├── Views
│   ├── Home
│   └── Shared
└── wwwroot
    ├── css
    ├── js
    └── lib
        ├── bootstrap
        │   └── dist
        │       ├── css
        │       └── js
        ├── jquery
        │   └── dist
        ├── jquery-validation
        │   └── dist
        └── jquery-validation-unobtrusive
            └── dist
````

---

# Định tuyến trong .NET MVC

* MVC sẽ gọi **Controller** và **Action** thông qua URL
* Cú pháp định tuyến:

```text
/[Controller]/[Action]/[Parameters]
```

* Định tuyến được cấu hình trong file `Program.cs`

---

# Controller và View trong .NET MVC

## Controller

### Giới thiệu

Controller là thành phần trung gian trong mô hình **MVC**, chịu trách nhiệm xử lý logic và điều phối dữ liệu giữa **View** và **Model**.

Các Controller được đặt trong thư mục `Controllers`, dùng để xử lý các yêu cầu từ View gửi về.

---

### Quy tắc đặt tên

* Tên Controller **bắt buộc phải có hậu tố `Controller`**
* Ví dụ:

  * `DemoController`
  * `HomeController`
* Tất cả Controller phải nằm trong thư mục `Controllers`

---

### Nhiệm vụ của Controller

* Xử lý các yêu cầu của người dùng gửi tới từ **View**
* Truy xuất và xử lý dữ liệu từ **cơ sở dữ liệu**
* Gọi các **View** tương ứng
* Trả kết quả đã xử lý về cho người dùng

---

### Vai trò trong mô hình MVC

Controller đóng vai trò là **cầu nối** giữa:

* **Model** – xử lý dữ liệu và nghiệp vụ
* **View** – hiển thị giao diện người dùng

---

### Ví dụ cấu trúc thư mục Controller

```text
Controllers/
├── DemoController.cs
├── HomeController.cs
```

---

## View

* Thư mục chứa các thành phần **hiển thị giao diện người dùng**
* Các file View có phần mở rộng **`.cshtml`**
* View được đặt trong thư mục:

```text
Views/Tên_Controller/
```

**Ví dụ:**
Controller `DemoController`
→ View nằm trong thư mục:

```text
Views/
```

---

### Nhiệm vụ của View

* Cung cấp giao diện người dùng (HTML)
* Kết hợp **C# Razor** để hiển thị dữ liệu động
* Không xử lý logic nghiệp vụ phức tạp


### câu lệnh sinh mã 
## Cài công cụ
dotnet tool install -g dotnet-aspnet-codegenerator
## Cài Package
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
## sinh mã
 dotnet aspnet-codegenerator controller -name TencontrollerController -m tên Model dc webmvc.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite 

 dotnet aspnet-codegenerator controller -name PictureController -m Picture -dc webmvc.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite    

giải thích chi tiết cách hoạt động từ tổng quan đến chi tiết của action get dữ liệu books này nó hoạt động như thế nào , nó có các thuộc tính gì , phương thức gì và đối tượng gì , nhiệm vụ của chúng là làm những gì có tác dụng gì , hoạt động như nào , có hỗ trợ nhau ra sao , để giải đáp thắc mắc cho 1 kẻ không biết gì về lập trình cũng hiểu

// Các bước Tạo Form 

1. Tạo Model ( db)
↓
2. Tạo Form (View)
↓
3. Submit dữ liệu
↓
4. Controller nhận dữ liệu
↓
5. Kiểm tra dữ liệu
↓
6. Lưu vào Database
↓
7. Chuyển sang trang hiển thị kết quả - tạo hiển thị dl
// Cú pháp Razor hay gặp trong hiển thị dl ở view
 @Model.Name     // lấy dữ liệu

@if(){}         // điều kiện

@foreach(){}    // lặp

@for(){}        // vòng lặp

@ViewBag.Name   // lấy ViewBag

@{
   // viết nhiều dòng C#
}
<details>
<summary> Ý tưởng upload file sử dụng ViewBag </summary>

### Bước 1
Tạo Action GET Fom() trả về View.


### Bước 2
Tạo View : hiển thị form 
- có thẻ input type="text" name = "fullname" để nhập name
- có thẻ input type = "file" name = "tacpham" để chọn ảnh
- có thẻ button type = "submit" để gửi dữ liệu
=> view hiển thị các trường để người dùng gửi dữ liệu, controller lấy yêu cầu và xử lý rồi gửi lại view

### Bước 3 
Tạo Action POST Fom(string fullname, IFormFile tacpham):
- dùng ViewBag.Name hiển thị dữ liệu của fullname
Kiểm tra nếu tacpham khác rỗng thì :
- tạo thư mục (folder)  wwwroot/images để lưu file upload 
- tạo fileName lưu tên tacpham (dùng tacpham.FileName)
- tạo path : đường dẫn lưu file
- lưu file : tạo FileStream 
          -  Khởi tạo đối tượng FileStream với đường dẫn file và chế độ Create
          -  Dùng phương thức CopyTo() để sao chép dữ liệu từ IFormFile sang FileStream
          -  Đóng stream sau khi lưu xong
- dùng ViewBag.Images hiển thị dữ liệu của tacpham

### Bước 4
Tạo View hiển thị dữ liệu :
- Hiển thị ViewBag.Name.
- Kiểm tra ViewBag.Images khác null.
- Hiển thị ảnh bằng thẻ img.

</details>

<details> 
Kết nối với cơ sở dữ liệu

Cài đặt tool hỗ trợ quản lý phiên bản CSDL (Migrations), tool hỗ trợ sinh mã nguồn

Cài đặt các package (các gói hỗ trợ để kết nối và làm việc với cơ sở dữ liệu)

Tạo file Data/ApplicationDbContext.cs

Cấu hình ở file appsettings.json

Cấu hình ở file Program.cs

Khai báo DbSet trong ApplicationDbContext.cs

Sử dụng Migrations để tạo cơ sở dữ liệu
<summary> sử dụng Migrations quản lý cơ sở dữ liệu </summary>

### Bước 1 : Tạo Model 

### Bước 2: Tạo DBContext

### Bước 3: Connection String
### Bước 4: Migration và Update Database

## Cách tạo Migration 
dotnet ef migrations add InitialCreate
dotnet ef database update

##
dotnet ef database drop - xóa toàn bộ 
dotnet ef migrations remove - xóa cái vừa tạo chưa update

## Cách xóa database đã update
B1. Xóa Entity và DbSet cần loại bỏ.
B2. Chạy:
    dotnet ef migrations add RemoveAuthorTable
B3. Chạy:
    dotnet ef database update
B4. Entity Framework sinh lệnh DropTable và xóa bảng khỏi database.

## Cách thêm sửa xóa thuộc tính của 1 class trong Model
B1. Chỉnh sửa Model.

B2. Tạo Migration mới:
    dotnet ef migrations add TenMigration

B3. Cập nhật Database:
    dotnet ef database update

B4. Entity Framework so sánh Model hiện tại với Migration trước đó và sinh các lệnh ALTER TABLE, ADD COLUMN, DROP COLUMN... để đồng bộ Database. 


### Bước 5: Scaffolde
## Tạo ViewModel 

## Tạo CRUD của Picture
# Action Index 
Tạo Action Get Index 
- tạo biến oject : truy cập vào bảng Picture -> lấy tất cả các thuộc tính của Picture bao gồm cả thuộc tính khóa ngoại bảng Author. 
- trả về dạng List<oject Picture>  // kiểu như 1 list các oject 

Tạo View của Index
- using bảng Picture
- Tạo đường liên kết tới Action Create
- Tạo bảng chứa các cột thuộc tính của List<Picture>
- Hiển thị bảng dùng foreach 
- Tạo các dlk edit, detail, delete 

# new SelectList(
    items,          // danh sách
    valueField,     // giá trị gửi đi
    textField,      // nội dung hiển thị
    selectedValue   // giá trị được chọn sẵn
)
ViewData["AuthorId"] = new SelectList(
    _context.Author,
    "Id",
    "Name",
    picture.AuthorId
);
# Action Create 
Tạo Get Create
Mục đích: mở form nhập dữ liệu.

Tạo ViewData["AuthorId"] hoặc ViewBag.AuthorId
Chứa danh sách SelectList
Hiển thị danh sách Author cho dropdown
Có thể có selectedValue hoặc không

Tạo View Create 
- Thẻ Name
- Thẻ ImagePath
- Thẻ selection 
- thẻ button
- đường liên kết quay về trang create



Tạo Post Create
- Kiểm tra ModeState của dữ liệu 
- Sử dụng ViewModel : tạo 1 oject thuộc Picture chứa các thuộc tính có trong ViewModel  để lưu dữ liệu vào trong db 
- Thêm vào db
- lưu dữ liệu vào bảng (dữ liệu mới nằm trong bảng Picture và hiển thị ở trang index)
- tạo đlk về trang chủ

# Action edit 
Tạo get edit cho tham số là id
- kiểm tra id có khác null
- lấy dữ liệu theo id cần chỉnh sửa: tạo biến picture -> truy cập bảng Picture -> lấy id => oject của 1 id trong bảng 
- kiểm tra biến picture khác null 
- trả về oject picture => chứa key ,value (thuộc tính) của id đưa sang View 

Tạo View Edit
- thẻ Name
- Thẻ ImagePath
- thẻ selection
- thẻ button

Tạo post edit 
- tạo form nhận dữ liệu
- Dùng Bind gán dữ liệu vào bảng thì :
  - kiểm tra dữ liệu (ModelState) nếu hợp lệ thì :
    -> Update() vào db
    -> Lưu
    -> trả về trang Index
- trả dữ liệu trên lên View  (hiển thi ở trang chủ )

# Action delete
Tạo get delete cho tham số ?id – hiển thị xác nhận
- kiểm tra id khác null 
- lấy dl của id: tạo oject -> truy cập bảng Picture và kèm khóa ngoại lấy dl của id 
- kiểm tra oject khác null
- trả về dl sang View

Tạo View delete
- Thẻ Name
- Thẻ ImagePath
- Thẻ Author
- Thẻ Button Delete
- link quay về trang chủ

Tạo post delete
- tạo form nhận dữ liệu từ controller
- lấy dl của id
- kiểm tra rỗng thì trả về notfound
- Xóa khỏi db 
- lưu
- trả về trang chủ


</details>

# Upload file excel 
<detail> 
<summary> Các bước thực hiện Upload file excel cho db Author </summary>

## Tạo View Import.cshtml 
Tạo form upload : asp-action là Import , method Post , enctype ...file
- thẻ input (file) 
- thẻ submit
- thẻ điều hướng

## Tạo Action get Import
Tạo mở form 

## Tạo Action post Import
Tạo nhận form có tham số IFormFile file
Import file Excel + lưu db:
- Kiểm tra file nếu == null || == file.Length == 0 thì
    ModelState.AddModelError(key, errorMessage);
    trả về dl sang view 
- Đọc dữ liệu và lưu
 


</detail>


```
Comment dòng code:
Ctrl + K, Ctrl + C
Ctrl + K, Ctrl + U
Bind = ASP.NET tự gán dữ liệu vào model theo các thẻ mà mình gọi
Find() không Include() được 