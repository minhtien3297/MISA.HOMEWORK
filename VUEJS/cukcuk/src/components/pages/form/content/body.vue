<template>
  <div class="content-body">
    <div class="b-row">
      <!-- avatar -->
      <div class="b-col">
        <div class="body-avatar">
          <div class="avatar"></div>

          <!-- avatar description -->
          <div class="avatar-des">
            Vui lòng chọn ảnh có định dạng
            <span>.jpg, .jpeg, .png, .gif.</span>
          </div>
        </div>
      </div>

      <!-- inputs -->
      <div class="b-col">
        <!-- thông tin chung -->
        <div class="b-row">
          <div>A. THÔNG TIN CHUNG:</div>
          <hr class="underline" />

          <div class="b-col">
            <!-- Mã nhân viên-->
            <div class="b-row">
              <label>Mã nhân viên <span>(*)</span>:</label>
              <input
                type="text"
                v-model.lazy="employee.EmployeeCode"
                readonly
              />
            </div>

            <!-- Ngày sinh -->
            <div class="b-row">
              <label>Ngày sinh:</label>
              <input
                type="date"
                :value="employee.DateOfBirth | formatDate"
                tabindex="3"
                @change="getInsertEmployee()"
              />
            </div>

            <!-- email -->
            <div class="b-row">
              <label>Email:</label>
              <input
                type="text"
                v-model.lazy="employee.Email"
                tabindex="7"
                @change="getInsertEmployee()"
              />
            </div>
          </div>

          <div class="b-col">
            <!-- Họ và tên -->
            <div class="b-row">
              <label>Họ và tên <span>(*)</span>:</label>
              <input
                type="text"
                v-model.lazy="employee.FullName"
                tabindex="2"
                @change="getInsertEmployee()"
              />
            </div>

            <!-- Giới tính-->
            <div class="b-row">
              <label>Giới tính:</label>
              <div class="radio-control">
                <input
                  type="radio"
                  v-model.lazy="employee.Gender"
                  name="gender"
                  :value="1"
                  tabindex="4"
                  @change="getInsertEmployee()"
                />
                <label>Nam</label>
                <input
                  type="radio"
                  v-model.lazy="employee.Gender"
                  name="gender"
                  :value="0"
                  tabindex="5"
                  @change="getInsertEmployee()"
                />
                <label>Nữ</label>
                <input
                  type="radio"
                  v-model.lazy="employee.Gender"
                  name="gender"
                  :value="2"
                  tabindex="6"
                  @change="getInsertEmployee()"
                />
                <label>Khác</label>
              </div>
            </div>

            <!-- Điện thoại -->
            <div class="b-row">
              <label>Điện thoại <span>(*)</span>:</label>
              <input
                type="text"
                v-model.lazy="employee.PhoneNumber"
                tabindex="8"
                @change="getInsertEmployee()"
              />
            </div>
          </div>
        </div>

        <!-- Thông tin công việc -->
        <div class="b-row">
          <div>B. THÔNG TIN CÔNG VIỆC:</div>
          <hr class="underline" />

          <div class="b-col">
            <!-- Chức vụ -->
            <div class="b-row">
              <label>Chức vụ:</label>
              <select
                v-model.lazy="employee.PositionId"
                tabindex="9"
                @change="getInsertEmployee()"
              >
                <option
                  v-for="position in positions"
                  :value="position.PositionId"
                  :key="position.index"
                  >{{ position }}</option
                >
              </select>
            </div>

            <!-- Mức lương -->
            <div class="b-row">
              <label>Mức lương:</label>
              <input
                type="text"
                v-model="employee.Salary"
                tabindex="11"
                @change="getInsertEmployee()"
              />
            </div>
          </div>

          <div class="b-col" style="width: 46%">
            <!-- Phòng ban -->
            <div class="b-row">
              <label>Phòng ban:</label>
              <select
                v-model.lazy="employee.DepartmentId"
                tabindex="10"
                @change="getInsertEmployee()"
              >
                <option
                  v-for="department in departments"
                  :value="department.DepartmentId"
                  :key="department.index"
                  >{{ department.DepartmentName }}</option
                >
              </select>
            </div>

            <!-- tình trạng công việc -->
            <div class="b-row">
              <label>Tình trạng công việc:</label>
              <select
                v-model.lazy="employee.WorkStatus"
                tabindex="12"
                @change="getInsertEmployee()"
              >
                <option value="0">Thực tập sinh</option>
                <option value="1">Đang thử việc</option>
                <option value="2">Nhân viên</option>
                <option value="3">Đã nghỉ việc</option>
              </select>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import EventBus from "../../../../main";
import axios from "axios";
import moment from "moment";

export default {
  props: {
    departments: Array,
    positions: Array,
  },

  data() {
    return {
      employee: {
        EmployeeId: "",
        EmployeeCode: "",
        FullName: "",
        Gender: "1",
        DateOfBirth: "",
        PhoneNumber: "",
        Email: "",
        PositionId: "",
        DepartmentId: "4e272fc4-7875-78d6-7d32-6a1673ffca7c",
        Salary: "",
        WorkStatus: "0",
      },
    };
  },

  async created() {
    // Nhận dữ liệu nhân viên được chọn qua event getSelectedEmployee
    await EventBus.$on("getSelectedEmployee", this.getSelectedEmployee);

    //Lấy mã nhân viên
    if (!this.employee.EmployeeCode) {
      await this.getEmployeeCode();
    }
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
     * Chuyển đổi kiểu hiện thị ngày
     * @param {String}
     * CreatedBy: DMTIEN (5/5/2021)
     */
    formatDate(date) {
      if (!date) {
        return "";
      }
      date = moment(date).format("yyyy-MM-dd");
      return date;
    },
  },

  methods: {
    /**
     * Gửi dữ liệu của nhân viên tới component footer form mỗi khi dữ liệu được thay đổi
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async getInsertEmployee() {
      await EventBus.$emit("getInsertEmployee", this.employee);
    },

    /**
     * Lấy dữ liệu nhân viên được chọn từ table
     * @param {Object}
     * CreatedBy: DMTIEN (20/4/2021)
     */
    async getSelectedEmployee(data) {
      this.employee = data;
    },

    /**
     * Lấy mã nhân viên
     * CreatedBy: DMTIEN (28/4/2021)
     */
    async getEmployeeCode() {
      const response = await axios.get(
        "http://cukcuk.manhnv.net/v1/Employees/NewEmployeeCode"
      );
      this.employee.EmployeeCode = response.data;
    },
  },
};
</script>

<style>
/* avatar */
.insert-form .form-content .content-body .body-avatar .avatar {
  background-image: url("../../../../assets/img/default-avatar.jpg");
  width: 200px;
  height: 200px;
  margin: auto;
  background-repeat: no-repeat;
  background-position: center;
  background-size: contain;
  border-radius: 50%;
  border: 1px solid lightgray;
}

/* avatar description */
.insert-form .form-content .content-body .body-avatar .avatar-des {
  text-align: center;
  margin-top: 10px;
}

.insert-form .form-content .content-body .body-avatar .avatar-des span {
  font-weight: bold;
  display: block;
}

/* inputs */
.insert-form .form-content .content-body input[type="text"],
input[type="date"],
select {
  border: 1px solid #bbbbbb;
  border-radius: 5px;
  height: 35px;
  width: 100%;
  margin-top: 5px;
  outline: none;
  padding: 0px 5px;
  box-sizing: border-box;
}

/* gạch chân tiêu đề */
.insert-form .form-content .content-body .underline {
  width: 100px;
  text-align: left;
  margin-left: 0;
  height: 2px;
  background-color: #2fbe8e;
}

/* radio buttons */
.insert-form .form-content .content-body .radio-control {
  display: flex;
  height: 40px;
  align-items: center;
}

.insert-form .form-content .content-body input[type="radio"] {
  height: 20px;
  width: 20px;
  margin-left: 15px;
}

/* Màu của (*) */
.insert-form .form-content .content-body label span {
  color: red;
}

/* Hiệu ứng trỏ vào label, input */
.insert-form .form-content .content-body input:hover,
select:hover {
  border: 1px solid #01b075;
  cursor: pointer;
}

.insert-form .form-content .content-body select[tabindex="9"]:focus,
select[tabindex="10"]:focus,
select[tabindex="11"]:focus,
select[tabindex="12"]:focus {
  background-color: #f1f3f4;
}

.insert-form .form-content .content-body input,
label {
  display: block;
}

/* row và col */
.b-row {
  margin-left: 10px;
  margin-top: 10px;
}

.b-row:after {
  content: "";
  display: table;
  clear: both;
  margin-top: 10px;
}

.b-col {
  float: left;
  padding: 0px 10px;
}
</style>
