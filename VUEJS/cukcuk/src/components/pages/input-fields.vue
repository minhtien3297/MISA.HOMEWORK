<template>
  <div class="input-field">
    <h2>Danh sách {{ title }}</h2>

    <!-- inputs -->
    <div class="inputs">
      <!-- search box -->
      <input
        type="text"
        name="search"
        class="icon-search"
        placeholder="Tìm kiếm theo mã, tên hoặc số điện thoại"
        autocomplete="off"
        v-model="query"
        @keyup="filterEmployee()"
      />

      <!-- Phòng ban combobox -->
      <select
        name="DepartmentName"
        @change="filterDepartment()"
        v-model="departmentName"
      >
        <option value="All">Tất cả phòng ban</option>
        <option v-for="department in departments" :key="department.index">{{
          department.DepartmentName
        }}</option>
      </select>

      <!-- Vị trí combobox -->
      <select
        name="PositionName"
        @click="filterPosition()"
        v-model="positionName"
      >
        <option value="All">Tất cả chức vụ</option>
        <option v-for="position in positions" :key="position.index">{{
          position
        }}</option>
      </select>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import EventBus from "../../main";

export default {
  props: {
    title: String,
    departments: Array,
    positions: Array,
  },

  data() {
    return {
      employee: [],

      departmentName: "All",

      positionName: "All",

      query: "",
    };
  },

  methods: {
    /**
     * Tìm nhân viên theo chuỗi nhập vào
     * Truyền dữ liệu của nhân viên tìm được tới component employee
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async filterEmployee() {
      const response = await axios.get(
        "http://cukcuk.manhnv.net/v1/Employees/employeeFilter?pageSize=1000&employeeFilter=" +
          this.query
      );

      this.employee = response.data;

      await this.$emit("getFilterEmployee", this.employee);
    },

    /**
     * Gửi dữ liệu của phòng ban được chọn tới component table
     * CreatedBy: DMTIEN (5/5/2021)
     */
    async filterDepartment() {
      await EventBus.$emit("filterDepartment", this.departmentName);
    },

    /**
     * Gửi dữ liệu của chức vụ được chọn tới component table
     * CreatedBy: DMTIEN (5/5/2021)
     */
    async filterPosition() {
      await EventBus.$emit("filterPosition", this.positionName);
    },
  },
};
</script>

<style>
/* input fields */
.body-right .content .content-header .input-field {
  width: 60%;
}

/* inputs */
.body-right .content .content-header .input-field .inputs {
  display: flex;
  align-items: center;
}

/* input style */
.body-right .content .content-header .input-field .inputs input[type="text"],
select {
  border: 1px solid #bbbbbb;
  border-radius: 5px;
  height: 35px;
  width: 100%;
  margin-top: 5px;
  outline: none;
  padding: 0px 5px;
  box-sizing: border-box;
  cursor: pointer;
}

/* search box */
.body-right .content .content-header .input-field .inputs input[type="text"] {
  width: 350px;
  padding-left: 40px;
}

/* search icon */
.body-right .content .content-header .input-field .inputs .icon-search {
  background-image: url("../../assets/icon/search.png");
  height: 24px;
  width: 24px;
  background-repeat: no-repeat;
  background-position: 16px center;
}

/* combobox */
.body-right .content .content-header .input-field .inputs select {
  margin-left: 16px;
  width: 150px;
}

/* Hiệu ứng trỏ vào label, input */
.body-right .content .content-header .input-field .inputs input:hover,
select:hover {
  border: 1px solid #01b075;
}

.body-right .content .content-header .input-field .inputs input:focus,
select:focus {
  border: 1px solid #01b075;
}
</style>
