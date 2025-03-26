# Form Submission System

A web-based form submission system built with ASP.NET Core and Vue.js, allowing users to submit and manage form entries.

## 📌 Features
- ✅ **User-friendly Contact Form** with fields for Full Name, Country, Date of Birth, Gender, and Terms Agreement.
- ✅ **Form Validation** to ensure required fields are filled and terms are accepted.
- ✅ **ASP.NET Core API** ASP.NET Core API
- ✅ **Data Storage with Entity Framework Core** for efficient data management.
- ✅ **Frontend UI** built with Vue.js for managing tasks visually


## 🚀 Installation & Setup

### **1️⃣ Clone the Repository**
```sh
git clone https://github.com/tarikhdamir/FormSubmission.git
cd FormSubmission
```
### **2️⃣ Install Dependencies**
```sh
dotnet restore
```
### **3️⃣ Apply Migrations**
```sh
dotnet ef database update
```
### **4️⃣ Run the Backend API**
```sh
dotnet run --launch-profile "https"
```
The API will be available at https://localhost:7217.
### **5️⃣ Set Up the Frontend (Vue.js)**
```sh
cd form-submission-ui
npm install
npm run dev
```
The frontend will be available at http://localhost:5173.

## 📖 API Endpoints

### ✅ Submit a Form
```http
POST /api/form
```
Request Body:

```JSON
{
  "fullName": "John Doe",
  "country": "USA",
  "dateOfBirth": "1990-05-15",
  "gender": "Male",
  "agreedToTerms": true
}
```
### ✅ Get All Submissions
```http
GET /api/form
```

## 🛠 Technologies Used
- **ASP.NET Core 8** - Web framework for building APIs.
- **Entity Framework Core** - ORM for database management.
- **SQLite** - Lightweight relational database.
- **Tailwind CSS** - For modern UI styling.
- **Vue.js (Vite)** - Frontend framework for building interactive UI.
- **Axios** - HTTP client for API requests.

📌 License
Distributed under the Unlicense License. See ```LICENSE.txt``` for more information.
