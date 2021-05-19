<template>
  <div class="content-header">
    <div class="content-title">Thông tin {{ title }}</div>

    <!-- nút thoát -->
    <button id="clsButton" class="content-close-button" @click="closedForm()">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        width="30"
        height="30"
        viewBox="0 0 24 24"
        fill="none"
        stroke="gray"
        stroke-width="2"
        stroke-linecap="round"
        stroke-linejoin="round"
        class="feather feather-x"
      >
        <line x1="18" y1="6" x2="6" y2="18"></line>
        <line x1="6" y1="6" x2="18" y2="18"></line>
      </svg>
    </button>
  </div>
</template>

<script>
export default {
  props: ["title"],

  data() {
    return {
      isShow: false,
    };
  },

  methods: {
    /**
     * Đóng form khi click button x
     * Gửi value của isShow tới component form
     * CreatedBy: DMTIEN (20/4/2021)
     */
    closedForm() {
      // Truyền value của isShow tới component form để đóng form
      this.$emit("isShowValue", this.isShow);
    },
  },
};
</script>

<style>
/* content header */
.insert-form .form-content .content-header {
  display: flex;
  align-items: center;
  height: 60px;
  padding: 0px;
  border: 0px;
}

/* content header title */
.insert-form .form-content .content-header .content-title {
  font-size: 30px;
  margin: 24px;
}

/* content header close button */
.insert-form .form-content .content-header .content-close-button {
  position: absolute;
  top: 0px;
  right: 0;
  border: none;
  background-color: #ffffff;
  border-top-right-radius: 4px;
  border-bottom-left-radius: 4px;
}

/* hiệu ứng làm bút thoát màu xám */
.insert-form .form-content .content-header .content-close-button:hover {
  background-color: #bbb;
  cursor: pointer;
}
</style>
