<template>
  <div class="buttons">
    <!-- Thêm button -->
    <button
      id="button-insert"
      class="button-insert"
      @click="openForm()"
      type="button"
    >
      <div class="icon-add"></div>
      <div class="btn-text">Thêm {{ title }}</div>
    </button>

    <!-- Reload -->
    <button class="button-reload" type="button" @click="getEmployee()"></button>
  </div>
</template>

<script>
import EventBus from "../../main";

export default {
  props: {
    title: String,
    getEmployee: Function,
  },

  data() {
    return {
      isShow: true,
    };
  },

  methods: {
    /**
     * Mở form khi click button thêm
     * Gửi value của isShow qua eventbus
     * CreatedBy: DMTIEN (20/4/2021)
     */
    openForm() {
      // truyền dữ liệu của isShow
      EventBus.$emit("isShowValue", this.isShow);
    },
  },
};
</script>

<style>
/* buttons */
.body-right .content .content-header .buttons {
  position: absolute;
  right: 16px;
  top: 65px;
}

/* Thêm nhân viên */
.body-right .content .content-header .buttons .button-insert {
  display: flex;
  align-items: center;
  height: 40px;
  padding-left: 16px;
  padding-right: 16px;
  background-color: #019160;
  border-radius: 4px;
  color: white;
  border: 1px solid #dbdeff;
  outline: none;
}

/* icon add */
.body-right .content .content-header .buttons .button-insert .icon-add {
  background-image: url("../../assets/icon/add.png");
  height: 16px;
  width: 16px;
  padding: 0px 8px;
  background-repeat: no-repeat;
}

/* hiệu ứng trỏ vào nút thêm nhân viên*/
.body-right .content .content-header .buttons .button-insert:hover {
  background-color: #2fbe8e;
  cursor:pointer;
}

/* reload */
.body-right .content .content-header .buttons .button-reload {
  background-image: url("../../assets/icon/refresh.png");
  height: 40px;
  width: 50px;
  background-repeat: no-repeat;
  border: 1px solid #dbdeff;
  border-radius: 4px;
  background-position: center;
  float: right;
  margin-top: 10px;
  outline: none;
}
/* Hiệu ứng trỏ chuột vào nút reload */
.body-right .content .content-header .buttons .button-reload:hover {
  background-color: #dadce0;
  cursor:pointer;
}
</style>