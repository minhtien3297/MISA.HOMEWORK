<template>
  <div class="content-footer">
    <div class="buttons">
      <!-- Nút lưu nhân viên đã thay đổi -->
      <button class="cancel-button" @click="closePopup()">
        <div class="btn-text">Hủy</div>
      </button>

      <!-- Nút hủy -->
      <button class="delete-button" @click="deleteEmployee()">Xóa</button>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import EventBus from "../../../../main";

export default {
  data() {
    return {
      isShow: false,

      employeeId: "",
    };
  },

  created() {
    // Nhận id nhân viên qua event deleteEmployee
    EventBus.$on("deleteEmployee", this.getDeleteEmployee);
  },

  methods: {
    /**
     * Xoá nhân viên
     * CreatedBy: DMTIEN (5/5/2021)
     */
    async deleteEmployee() {
      await axios.delete(
        "http://cukcuk.manhnv.net/v1/Employees/" + this.employeeId
      );

      // Đóng popup
      this.closePopup();
    },

    /**
     * Truyền id nhân viên vào biến
     * CreatedBy: DMTIEN (5/5/2021)
     */
    async getDeleteEmployee(id) {
      this.employeeId = id;
    },

    /**
     * Đóng popup
     * CreatedBy: DMTIEN (5/5/2021)
     */
    async closePopup() {
      await this.$emit("isShowValue", this.isShow);
    },
  },
};
</script>

<style>
.delete-popup .popup-content .content-footer {
  position: absolute;
  bottom: 0;
  height: 60px;
  background-color: #e9ebee;
  width: 100%;
  border-radius: 5px;
}

/* Vị trí các nút */
.delete-popup .popup-content .content-footer .buttons {
  position: absolute;
  right: 10px;
  top: 10px;
  display: flex;
}

/* Định dạng các button */
.delete-popup .popup-content .content-footer button {
  height: 40px;
  padding-left: 24px;
  padding-right: 24px;
  background-color: #e9ebee;
  border-radius: 4px;
  outline: none;
  border: 1px solid #e9ebee;
  cursor: pointer;
}

/* Hiệu ứng trỏ vào nút xóa*/
.delete-popup .popup-content .content-footer .delete-button:hover {
  background-color: #f78484;
}

/* Nút xóa */
.delete-popup .popup-content .content-footer .delete-button {
  display: flex;
  align-items: center;
  margin-left: 16px;
  margin-right: 24px;
  background-color: #f65454;
  color: white;
}

/* Nút hủy */
.delete-popup .popup-content .content-footer .cancel-button:hover {
  background-color: #dadce0;
}
</style>
