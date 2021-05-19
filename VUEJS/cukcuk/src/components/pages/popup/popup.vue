<template>
  <div v-if="isShow" class="delete-popup">
    <!-- Nền tối -->
    <div class="popup-model"></div>

    <!-- content -->
    <div class="popup-content">
      <!-- header -->
      <Header @isShowValue="closedPopup($event)"></Header>

      <!-- body -->
      <Body></Body>

      <!-- footer -->
      <Footer @isShowValue="closedPopup($event)"></Footer>
    </div>
  </div>
</template>

<script>
import Header from "../popup/content/header";
import Footer from "../popup/content/footer";
import Body from "../popup/content/body";
import EventBus from "../../../main";

export default {
  components: {
    Footer,
    Header,
    Body,
  },

  data() {
    return {
      isShow: "",
    };
  },

  created() {
    // Nhận value isShow qua event openPopup
    EventBus.$on("openPopup", this.openPopup);
  },

  methods: {
    /**
     * Nhận dữ liệu của isShow từ component header đóng popup
     * @param{Boolean}
     * CreatedBy: DMTIEN (5/5/2021)
     */
    closedPopup(data) {
      this.isShow = data;
    },

    /**
     * Nhận dữ liệu của isShow từ component table để mở popup
     * @param{Boolean}
     * CreatedBy: DMTIEN (5/5/2021)
     */
    openPopup(data) {
      this.isShow = data;
    },
  },
};
</script>

<style>
/* Nền tối */
.delete-popup .popup-model {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: black;
  opacity: 0.4;
}

/* content */
.delete-popup .popup-content {
  position: absolute;
  bottom: calc(50% - 90px);
  right: calc(50% - 90px);
  height: 200px;
  width: 400px;
  background-color: #ffffff;
  border-radius: 4px;
}
</style>
