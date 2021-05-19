<template>
  <div class="content-footer">
    <div class="buttons">
      <!-- Nút hủy -->
      <button
        v-if="employee.EmployeeId"
        class="delete-button"
        @click="deleteEmployee()"
      >
        XÓA
      </button>

      <!-- Nút lưu nhân viên mới -->
      <button
        v-if="!employee.EmployeeId"
        class="save-button"
        @click="insertEmployee()"
      >
        <div class="icon">&#128427;</div>
        <div class="btn-text">LƯU</div>
      </button>

      <!-- Nút lưu nhân viên đã thay đổi -->
      <button
        v-if="employee.EmployeeId"
        class="save-button"
        @click="updateEmployee()"
      >
        <div class="icon">&#128427;</div>
        <div class="btn-text">LƯU</div>
      </button>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import EventBus from "../../../../main";

export default {
  props: {
    getEmployee: Function,
  },

  data() {
    return {
      employee: {
        EmployeeId: "",
        EmployeeCode: "",
        FullName: "",
        Gender: "",
        DateOfBirth: "",
        PhoneNumber: "",
        Email: "",
        PositionId: "",
        DepartmentId: "",
        Salary: "",
        WorkStatus: "",
      },

      isShow: false,
    };
  },

  created() {
    // Nhận dữ liệu nhân viên qua event insertEmployee
    EventBus.$on("getInsertEmployee", this.getInsertEmployee);

    // Nhận dữ liệu nhân viên được chọn qua event getSelectedEmployee
    EventBus.$on("getSelectedEmployee", this.getSelectedEmployee);
  },

  methods: {
    /**
     * Gán dữ liệu nhân viên vào biến employee
     * @param {Object}
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async getInsertEmployee(data) {
      this.employee = data;
    },

    /**
     * Đóng form và cập nhật lại dữ liệu
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async closedForm() {
      // Truyền value của isShow tới component form để đóng form
      await this.$emit("isShowValue", this.isShow);

      // tải lại dữ liệu nhân viên
      await this.getEmployee();

      // Xóa dữ liệu nhân viên cũ
      //await this.clearData();
    },

    /**
     * Thêm nhân viên mới
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async insertEmployee() {
      await axios.post("http://cukcuk.manhnv.net/v1/Employees", this.employee);

      await this.closedForm();
    },

    /**
     * Cập nhật thông tin nhân viên
     * @param {Object}
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async updateEmployee() {
      await axios.put(
        "http://cukcuk.manhnv.net/v1/Employees/" + this.employee.EmployeeId,
        this.employee
      );

      await this.closedForm();
    },

    /**
     * Lấy dữ liệu nhân viên được chọn từ table
     * @param {Object}
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async getSelectedEmployee(data) {
      this.employee = data;
    },

    /**
     * Xóa nhân viên
     * Gửi value của isShow tới component form
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async deleteEmployee() {
      // Mở popup cảnh báo
      await EventBus.$emit("openPopup", this.isShow = true);

      // Gửi id của nhân viên cần xoá tới component popup
      await EventBus.$emit("deleteEmployee", this.employee.EmployeeId);

      // Đóng form
      await this.closedForm();
    },

    /**
     * Xóa dữ liệu nhân viên cũ
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async clearData() {
      this.employee.EmployeeId = "";
      this.employee.EmployeeCode = "";
      this.employee.FullName = "";
      this.employee.Gender = "";
      this.employee.DateOfBirth = "";
      this.employee.PhoneNumber = "";
      this.employee.Email = "";
      this.employee.PositionId = "";
      this.employee.DepartmentId = "";
      this.employee.Salary = "";
      this.employee.WorkStatus = "";
    },
  },
};
</script>

<style>
.insert-form .form-content .content-footer {
  position: absolute;
  bottom: 0;
  height: 60px;
  background-color: #e9ebee;
  width: 100%;
  border-radius: 5px;
}

/* Vị trí các nút */
.insert-form .form-content .content-footer .buttons {
  position: absolute;
  right: 10px;
  top: 10px;
  display: flex;
}

/* Định dạng các button */
.insert-form .form-content .content-footer button {
  height: 40px;
  padding-left: 16px;
  padding-right: 16px;
  background-color: #e9ebee;
  border-radius: 4px;
  outline: none;
  border: 1px solid #e9ebee;
  cursor: pointer;
}

/* Nút xóa */
.insert-form .form-content .content-footer .delete-button {
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

/* Hiệu ứng trỏ vào nút xóa*/
.insert-form .form-content .content-footer .delete-button:hover {
  background-color: #f78484;
}

/* Nút lưu */
.insert-form .form-content .content-footer .save-button {
  display: flex;
  align-items: center;
  margin-left: 16px;
  background-color: #019160;
  color: white;
}

/* Floppy disk icon */
.insert-form .form-content .content-footer .save-button .icon {
  padding-right: 8px;
  padding-bottom: 2px;
  font-size: 15px;
}

/* Hiệu ứng trỏ chuột vào nút lưu */
.insert-form .form-content .content-footer .save-button:hover {
  background-color: #2fbe8e;
}
</style>
