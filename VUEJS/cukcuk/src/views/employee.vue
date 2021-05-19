<template>
  <div class="employee">
    <!-- content header -->
    <div class="content-header">
      <!-- content header input field -->
      <input-fields
        :title="title"
        @getFilterEmployee="getFilterEmployee($event)"
        :departments="departments"
        :positions="positions"
      ></input-fields>

      <!-- content header buttons -->
      <Buttons :title="title" :getEmployee="getEmployee" />
    </div>

    <!-- content table -->
    <Table :employees="employees" :getEmployee="getEmployee" />

    <!-- form -->
    <Form
      :title="title"
      :getEmployee="getEmployee"
      :departments="departments"
      :positions="positions"
    ></Form>

    <!-- popup -->
    <popup></popup>
  </div>
</template>

<script>
import Table from "../components/pages/table.vue";
import InputFields from "../components/pages/input-fields.vue";
import Buttons from "../components/pages/buttons.vue";
import Form from "../components/pages/form/form.vue";
import axios from "axios";
import Popup from "../components/pages/popup/popup.vue";

export default {
  components: {
    Table,
    InputFields,
    Buttons,
    Form,
    Popup,
  },

  data() {
    return {
      employees: [],

      departments: [],

      positions: [],

      title: "nhân viên",
    };
  },

  mounted() {
    this.getEmployee();
    this.getDepartment();
    this.getPosition();
  },

  methods: {
    /**
     * Lấy dữ liệu nhân viên
     * CreatedBy: DMTIEN (20/4/2021)
     */
    async getEmployee() {
      const response = await axios.get("http://cukcuk.manhnv.net/v1/Employees");
      this.employees = response.data;
    },

    /**
     * Truyền dữ liệu nhân viên tìm được vào bảng
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async getFilterEmployee(res) {
      // if (res.Data) {
      this.employees = res.Data;
      // } else {
      // await this.getEmployee();
      // }
    },

    /**
     * Lấy dữ liệu phòng ban
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async getDepartment() {
      const response = await axios.get(
        "http://cukcuk.manhnv.net/api/Department"
      );
      this.departments = response.data;
    },

    /**
     * Lấy dữ liệu chức vụ
     * CreatedBy: DMTIEN (4/5/2021)
     */
    async getPosition() {
      const response = await axios.get("http://cukcuk.manhnv.net/v1/Positions");
      this.positions = response.data;
    },
  },
};
</script>

<style></style>
