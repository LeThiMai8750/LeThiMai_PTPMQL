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

```




