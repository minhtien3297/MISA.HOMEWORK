<template>
  <div class="user-info">
    <!-- avatar -->
    <div class="user-info-item">
      <img class="avatar" src="../../../../assets/icon/avatar-default.png" />
    </div>

    <!-- username -->
    <div class="user-info-item"><h4>Đào Minh Tiến</h4></div>

    <!-- option icon -->
    <div class="user-info-item">
      <img class="option" src="../../../../assets/icon/option.png" />
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style>
/* user info */
.body-right .header .user-info{
    display: flex;
    align-items: center;
    margin-left: auto;
    padding: 0px 16px 0px 0px;
}
    .body-right .header .user-info .user-info-item{
        padding: 0px 8px;
        cursor: pointer;
    }

        /* user image */
        .body-right .header .user-info .avatar{
            height: 30px;
        }

        /* option */
        .body-right .header .user-info .option{
            height: 20px;
        }
</style>