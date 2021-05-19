$(document).ready(function () {
  showForm();
  hideForm();
  highlight();
  getData();
  getDataById();
});

/**
 *  Hiển thị form insert
 * CreatedBy: DMTIEN (15/4/2021)
 */
function showForm() {
  //Hiện form khi ấn vào nút thêm
  $("#button-insert").click(function () {
    $("#insert-form").removeClass("insert-form-hide");
  });
}

/**
 * Ẩn form insert
 * CreatedBy: DMTIEN (15/4/2021)
 */
function hideForm() {
  // Ẩn form khi ấn vào nút thoát
  $("#clsButton").click(function () {
    $("#insert-form").addClass("insert-form-hide");
  });
}

/**
 * lấy dữ liệu nhân viên vào table
 * CreatedBy: DMTIEN (15/4/2021)
 */
function getData() {
  //Lấy dữ liệu từ api bằng ajax
  $.ajax({
    url: "http://api.manhnv.net/v1/Employees",
    method: "GET",
  })
    .done(function (response) {
      var data = response;

      //build lên table
      $.each(data, function (index, item) {
        // Chuyển đổi kiểu hiển thị tiền
        var moneyFormat = formatMoney(item.Salary);

        // Chuyển đổi kiểu hiển thị ngày sinh
        var DateOfBirth = formatDateOfBirth(item.DateOfBirth);

        // Chuyển đổi kiểu hiển thị giới tính
        var Gender = getGender(item.Gender);

        // Chuyển đổi kiểu hiển thị tình trạng công việc
        var checkBoxHTML =
          item.workStatus == 0
            ? `<input type="checkbox" disabled>`
            : `<input type="checkbox" checked disabled>`;

        // Gán dữ liệu vào biến trHTML
        var trHTML = `<tr>
            <input type="hidden" value="${item.EmployeeId}" class="employeeID">
            <td>${validate(item.EmployeeCode)}</td>
            <td>${validate(item.FullName)}</td>
            <td>${validate(Gender)}</td>
            <td>${validate(DateOfBirth)}</td>
            <td>${validate(item.PhoneNumber)}</td>
            <td>${validate(item.Email)}</td>
            <td>${validate(item.PositionName)}</td>
            <td>${validate(item.DepartmentName)}</td>
            <td class="text-align-right">${validate(moneyFormat)}</td>
            <td class="text-align-center">${checkBoxHTML}</td>
            </tr>`;

        // Gán dữ liệu vào tbody
        $("#tblEmployee > tbody").append(trHTML);
      });
    })
    .fail(function () {});
}

/**
 * Chuyển đổi kiểu hiển thị tiền
 * @param {Number} money Số tiền dạng decimal
 * CreatedBy: DMTIEN (15/4/2021)
 */
function formatMoney(money) {
  if (money) {
    var moneyFormat =
      money.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,") + " VND";

    return moneyFormat;
  }
}

/**
 * Chuyển đổi kiểu hiển thị ngày sinh
 * @param {DateTime} date Ngày sinh dạng datetime
 * CreatedBy: DMTIEN (15/4/2021)
 */
function formatDateOfBirth(date) {
  if (date) {
    var newDate = new Date(date);
    var dateString = newDate.getDate();
    var monthString = newDate.getMonth() + 1;
    var year = newDate.getFullYear();

    return `${dateString}/${monthString}/${year}`;
  }
}

/**
 * Chuyển đổi kiểu hiển thị giới tính
 * @param {Int} gender
 * CreatedBy: DMTIEN (15/4/2021)
 */
function getGender(gender) {
  if (gender == 0) {
    return "Nam";
  } else if (gender == 1) {
    return "Nữ";
  } else {
    return "Khác";
  }
}

/**
 * Hiển thị dữ liệu của dòng được chọn lên form
 * CreatedBy: DMTIEN (16/4/2021)
 */
function getDataById() {
  $(document).on("click", "tr", function () {
    // Tìm id của employee
    let id = $(this).find(".employeeID").val();

    // Gán dữ liệu vào form theo id
    $.ajax({
      url: `http://api.manhnv.net/v1/Employees/${id}`,
      method: "GET",
    }).done(function (response) {
      var data = response;
      console.log(data);
      $(".EmployeeCode").val(validate(data.EmployeeCode));
      $(".PhoneNumber").val(validate(data.PhoneNumber));
      $(".Gender").val(data.Gender);
      $(".DateOfBirth").val(data.DateOfBirth);

      // Chuyển đổi kiểu hiển thị tiền
      var moneyFormat = formatMoney(data.Salary);
      $(".Salary").val(validate(moneyFormat));

      $(".FullName").val(validate(data.FullName));
      $(".PositionName").val(validate(data.PositionName));
      $(".DepartmentName").val(validate(data.DepartmentName));
      $(".Email").val(validate(data.Email));

      // Chuyển đổi kiểu hiển thị tình trạng công việc
      var checkBoxHTML =
        data.workStatus == 0
          ? `<input type="checkbox">`
          : `<input type="checkbox" checked>`;
      $(".workStatus").replaceWith(checkBoxHTML);

      //Hiện form insert
      $("#insert-form").removeClass("insert-form-hide");
    });
  });
}

function updateDataById() {}

/**
 * highlight selected row
 * CreatedBy: DMTIEN (16/4/2021)
 */
function highlight() {
  $(function () {
    $("#tblEmployee").on("click", "tbody tr", function (event) {
      $(this).addClass("highlight").siblings().removeClass("highlight");
    });
  });
}

/**
 * Validate dữ liệu truyền vào
 * @param {*} item  Kiểu dữ liệu bất kỳ
 * @returns dữ liệu bất kỳ hoặc thông báo
 */
function validate(item) {
  if (!item) {
    return (item = "Không có dữ liệu!");
  } else {
    return item;
  }
}
