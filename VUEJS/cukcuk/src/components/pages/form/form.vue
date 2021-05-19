<template>
  <!-- form -->
  <div v-if="isShow" id="insert-form" class="insert-form">
    <!-- Nền tối -->
    <div class="form-model"></div>

    <!-- content -->
    <div class="form-content">
      <!-- header -->
      <Header @isShowValue="closedForm($event)" :title="title"></Header>

      <!-- body -->
      <Body :departments="departments" :positions="positions" />

      <!-- footer -->
      <Footer @isShowValue="closedForm($event)" :getEmployee="getEmployee" />
    </div>
  </div>
</template>

<script>
import Header from "../form/content/header.vue";
import Body from "../form/content/body.vue";
import Footer from "../form/content/footer.vue";
import EventBus from "../../../main";

export default {
  components: { Header, Body, Footer },

  props: {
    title: String,
    getEmployee: Function,
    departments: Array,
    positions: Array,
  },

  data() {
    return {
      isShow: "",
    };
  },

  created() {
    // Nhận value isShow qua event isShowValue
    EventBus.$on("isShowValue", this.openForm);
  },

  methods: {
    /**
     * Nhận dữ liệu của isShow từ component header đóng form
     * @param{Boolean}
     * CreatedBy: DMTIEN (20/4/2021)
     */
    closedForm(data) {
      this.isShow = data;
    },

    /**
     * Nhận dữ liệu của isShow từ component buttons để mở form
     * @param{Boolean}
     * CreatedBy: DMTIEN (20/4/2021)
     */
    openForm(data) {
      this.isShow = data;
    },
  },
};
</script>

<style>
/* Nền tối */
.insert-form .form-model {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: black;
  opacity: 0.4;
}

/* content */
.insert-form .form-content {
  position: absolute;
  bottom: calc(50% - 325px);
  right: calc(50% - 250px);
  height: 650px;
  width: 700px;
  background-color: #ffffff;
  border-radius: 4px;
}
</style>
