<template>
  <div class="content-body">
    <div class="circle">
      <span>&#9888;</span>
    </div>
    <div>Bạn có chắc chăn muốn xóa nhân viên này không?</div>
  </div>
</template>

<script>
export default {};
</script>

<style>
.delete-popup .popup-content .content-body {
  display: flex;
  align-items: center;
  height: 25%;
  font-size: 13px;
}

/* Nền tròn của icon */
.delete-popup .popup-content .content-body .circle {
  background-color: #e9ebee;
  height: 50px;
  width: 50px;
  border-radius: 50%;
  text-align: center;
  line-height: 45px;
  margin-right: 10px;
  margin-left: 24px;
}

/* icon cảnh báo */
.delete-popup .popup-content .content-body .circle span {
  font-size: 30px;
  color: #f65454;
}
</style>