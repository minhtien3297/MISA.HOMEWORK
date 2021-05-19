<template>
  <div class="content-table">
    <table id="tblEmployee">
      <thead>
        <tr>
          <th>Mã nhân viên</th>
          <th>Họ và tên</th>
          <th>Giới tính</th>
          <th>Ngày sinh</th>
          <th>Điện thoại</th>
          <th>Email</th>
          <th>Chức vụ</th>
          <th>Phòng ban</th>
          <th class="text-align-right">Mức lương</th>
          <th class="text-align-center">Tình trạng công việc</th>
          <th class="text-align-center">Xóa</th>
        </tr>
      </thead>
      <tbody
        v-for="employee in employees"
        :key="employee.EmployeeId"
        @dblclick="getSelectedEmployee(employee)"
      >
        <tr
          v-if="
            selectedDepartment == employee.DepartmentName
            //&& selectedPosition == employee.PositionName
          "
        >
          <td>{{ employee.EmployeeCode }}</td>
          <td>{{ employee.FullName }}</td>
          <td>{{ employee.Gender | formatGender }}</td>
          <td>{{ employee.DateOfBirth | formatDateOFBirth }}</td>
          <td>{{ employee.PhoneNumber }}</td>
          <td>{{ employee.Email }}</td>
          <td>{{ employee.PositionName }}</td>
          <td>{{ employee.DepartmentName }}</td>
          <td class="text-align-right">
            {{ employee.Salary | formatMoney }}
          </td>
          <td class="text-align-center">
            {{ employee.WorkStatus | formatWorkStatus }}
          </td>
          <td>
            <button
              class="delete-btn"
              @click="deleteEmployee(employee.EmployeeId)"
            >
              Xóa
            </button>
          </td>
        </tr>

        <tr
          v-else-if="
            selectedDepartment == 'All'
            //&& selectedPosition == 'All'
          "
        >
          <td>{{ employee.EmployeeCode }}</td>
          <td>{{ employee.FullName }}</td>
          <td>{{ employee.Gender | formatGender }}</td>
          <td>{{ employee.DateOfBirth | formatDateOFBirth }}</td>
          <td>{{ employee.PhoneNumber }}</td>
          <td>{{ employee.Email }}</td>
          <td>{{ employee.PositionName }}</td>
          <td>{{ employee.DepartmentName }}</td>
          <td class="text-align-right">
            {{ employee.Salary | formatMoney }}
          </td>
          <td class="text-align-center">
            {{ employee.WorkStatus | formatWorkStatus }}
          </td>
          <td>
            <button
              class="delete-btn"
              @click="deleteEmployee(employee.EmployeeId)"
            >
              Xóa
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import EventBus from "../../main";

export default {
  props: {
    employees: Array,
    getEmployee: Function,
  },

  data() {
    return {
      isShow: true,

      selectedEmployee: {
        EmployeeId: "",
        EmployeeCode: "",
        FullName: "",
        Gender: "",
        DateOfBirth: "",
        PhoneNumber: "",
        Email: "",
        PositionName: "",
        PositionId: "",
        DepartmentName: "",
        DepartmentId: "",
        Salary: "",
        WorkStatus: "",
      },

      selectedDepartment: "All",

      selectedPosition: "All",
    };
  },

  filters: {
    /**
     * Chuyển đổi kiểu hiển thị tiền theo VND
     * @param {Int}
     * CreatedBy: DMTIEN (20/4/2021)
     */
    formatMoney(salary) {
      if (!salary) {
        return "";
      }
      var formatter = new Intl.NumberFormat("de-DE", {
        style: "currency",
        currency: "VND",
        minimumFractionDigits: 0,
      });

      return formatter.format(salary);
    },

    /**
     * Chuyển đổi kiểu hiển thị ngày tháng
     * @param {DateTime}
     * CreatedBy: DMTIEN (20/4/2021)
     */
    formatDateOFBirth(date) {
      if (date) {
        var newDate = new Date(date);
        var dateString = newDate.getDate();
        var monthString = newDate.getMonth() + 1;
        var year = newDate.getFullYear();

        // Thêm số 0 nếu ngày nhỏ hơn 10
        if (dateString < 10) {
          dateString = "0" + dateString;
        }

        // Thêm số 0 nếu tháng nhỏ hơn 10
        if (monthString < 10) {
          monthString = "0" + monthString;
        }

        return `${dateString}/${monthString}/${year}`;
      }
    },

    /**
     * Chuyển đổi kiểu hiển thị giới tính
     * @param {Int}
     * CreatedBy: DMTIEN (20/4/2021)
     */
    formatGender(sex) {
      var formatSex = "";

      switch (sex) {
        case 0:
          return (formatSex = "Nữ");
        case 1:
          return (formatSex = "Nam");
        case 2:
          return (formatSex = "khác");
      }

      return formatSex;
    },

    /**
     * Chuyển đổi kiểu hiển thị trạng thái công việc
     * @param {Int}
     * CreatedBy: DMTIEN (28/4/2021)
     */
    formatWorkStatus(status) {
      var formatWorkStatus = "";

      switch (status) {
        case 0:
          return (formatWorkStatus = "Thực tập sinh");
        case 1:
          return (formatWorkStatus = "Đang thử việc");
        case 2:
          return (formatWorkStatus = "Nhân viên");
        case 3:
          return (formatWorkStatus = "Đã nghỉ việc");
      }

      return formatWorkStatus;
    },
  },

  created() {
    // Nhận dữ liệu của phòng ban được chọn
    EventBus.$on("filterDepartment", this.filterDepartment);

    // Nhận dữ liệu của chức vụ được chọn
    EventBus.$on("filterPosition", this.filterPosition);
  },

  methods: {
    /**
     * Mở form khi click vào 1 dòng
     * Gửi value của isShow qua eventbus
     * CreatedBy: DMTIEN (20/4/2021)
     */
    openForm() {
      // truyền dữ liệu của isShow
      EventBus.$emit("isShowValue", this.isShow);
    },

    /**
     * lấy dữ liệu của nhân viên được chọn và truyền tới form
     * @param {Object}
     * CreatedBy: DMTIEN (20/4/2021)
     */
    async getSelectedEmployee(data) {
      // Mở form
      await this.openForm();

      // Gán dữ liệu nhân viên được chọn vào biến
      this.selectedEmployee = data;

      // Truyền dữ liệu nhân viên tới form
      await EventBus.$emit("getSelectedEmployee", this.selectedEmployee);
    },

    /**
     * Xóa nhân viên
     * @param {string}
     * CreatedBy: DMTIEN (5/5/2021)
     */
    async deleteEmployee(id) {
      // Mở popup cảnh báo
      await EventBus.$emit("openPopup", this.isShow);

      // Gửi id của nhân viên cần xoá tới component popup
      await EventBus.$emit("deleteEmployee", id);

      // Lấy lại dữ liệu nhân viên mới
      await this.getEmployee();
    },

    /**
     * Gán dữ liệu của phòng ban được chọn vào biến
     * @param {String}
     * CreatedBy: DMTIEN (5/5/2021)
     */
    async filterDepartment(department) {
      this.selectedDepartment = department;
    },

    /**
     * Gán dữ liệu của chức vụ được chọn vào biến
     * @param {String}
     * CreatedBy: DMTIEN (5/5/2021)
     */
    async filterPosition(position) {
      this.selectedPosition = position;
    },
  },
};
</script>

<style>
/* content table*/
.body-right .content .content-table {
  padding: 0px 14px;
  height: calc(100vh - 232px);
  overflow: auto;
}

/* table */
.body-right .content .content-table table {
  border-collapse: collapse;
  width: 100%;
  cursor: pointer;
}

/* Giữ table head luôn luôn trên cùng */
.body-right .content .content-table th {
  position: sticky;
  top: 0;
  background-color: #ffffff;
}

/* table head và table data */
.body-right .content .content-table th,
td {
  padding: 8px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}

/* Nút xóa */
.body-right .content .content-table td .delete-btn {
  display: flex;
  align-items: center;
  height: 40px;
  padding-left: 16px;
  padding-right: 16px;
  background-color: #f65454;
  border-radius: 4px;
  color: white;
  border: 1px solid #dbdeff;
  outline: none;
  margin: auto;
  cursor: pointer;
}

.body-right .content .content-table td button:hover {
  background-color: #f78484;
}

/* hiệu ứng màu đan xen của table row */
.body-right .content .content-table tbody:nth-child(even) {
  background-color: #f4f4f4;
}

/* hiệu ứng trỏ table row*/
.body-right .content .content-table tbody:hover {
  background-color: #dadce0;
}

.text-align-right {
  text-align: right !important;
}

.text-align-center {
  text-align: center !important;
}

/* style thanh scroll */
/* width */
::-webkit-scrollbar {
  width: 5px;
}

/* Track */
::-webkit-scrollbar-track {
  -webkit-box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
  box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
  background: #f1f1f1;
  border-radius: 10px;
}

/* Handle */
::-webkit-scrollbar-thumb {
  background: #888;
  border-radius: 10px;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: #555;
}
</style>
