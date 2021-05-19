<template>
  <div class="body-right">
    <Header />

    <!-- content -->
    <div class="content">
      <router-view></router-view>
      <hr style="margin: 0px 14px" />

      <!-- content footer -->
      <div class="content-footer">
        <div class="employee-count">Hiển thị 1-10/1000 nhân viên</div>

        <!-- pagination -->
        <pagination></pagination>
        <!-- Tổng số nhân viên 1 trang -->
        <div class="employee-per-page">10 nhân viên/trang</div>
      </div>
    </div>
  </div>
</template>

<script>
import Header from "./content/header.vue";
import Pagination from "./content/pagination.vue";

export default {
  components: {
    Header,
    Pagination,
  },
};
</script>

<style>
/* body right */
.body-right {
  position: absolute;
  top: 0;
  right: 0;
  left: 227px;
  bottom: 0;
}

/* content header*/
.body-right .content .content-header {
  border-top: 1px solid #bbbbbb;
  height: 120px;
  padding: 0px 16px 0px 16px;
}

/* content footer*/
.body-right .content .content-footer {
  height: 56px;
  position: fixed;
  bottom: 0;
  right: 0;
  width: calc(100% - 226px);
  display: flex;
  align-items: center;
}

/* đếm số nhân viên */
.body-right .content .content-footer .employee-count {
  padding: 0px 16px;
}

/* tổng số lượng nhân viên 1 trang */
.body-right .content .content-footer .employee-per-page {
  padding-right: 20px;
}
</style>