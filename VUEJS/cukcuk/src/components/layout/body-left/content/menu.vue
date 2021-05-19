<template>
  <div class="menu">
    <!-- Tổng quan -->
    <a class="menu-item" href="#">
      <div class="icon overview"></div>
      <div class="item-name">Tổng quan</div> </a
    >

    <!-- Báo cáo -->
    <a class="menu-item" href="#">
      <div class="icon report"></div>
      <div class="item-name">Báo cáo</div>
    </a>

    <!-- Danh mục khách hàng -->
    <router-link class="menu-item" to="/customer">
      <div class="icon employee-list"></div>
      <div class="item-name">Danh sách khách hàng</div>
    </router-link>

    <!-- Danh mục nhân viên  -->
    <router-link class="menu-item" to="/employee">
      <div class="icon employee-list"></div>
      <div class="item-name">Danh sách nhân viên</div>
    </router-link>

    <!-- Thiết lập hệ thống -->
    <a class="menu-item" href="#">
      <div class="icon setting"></div>
      <div class="item-name">Thiết lập hệ thống</div>
    </a>
  </div>
</template>

<script>
export default {};
</script>

<style>
/* menu */
.body-left .menu{
    position: relative;
    flex: 1;
}

    /* Menu item */
    .body-left .menu .menu-item{
        display: flex;
        align-items: center;
        cursor: pointer;
        font-family: MISA-Regular;
        text-decoration: none;
        color: #000000
    }

    /* hiệu ứng trỏ và chọn menu item */
    .body-left .menu .menu-item:hover{
        background-color: #DADCE0;
    }

    .body-left .menu .menu-item:focus{
        background-color: #DADCE0;
    }

        /* icon menu item */
        .body-left .menu .menu-item .icon{
            width: 50px;
            height: 44px;
            background-repeat: no-repeat;
            background-size: 20px;
            background-position: 18px center;
        }

        /* Tổng quan */
        .body-left .menu .menu-item .icon.overview{
            background-image: url('../../../../assets/icon/dashboard.png');
        }

        /* Báo cáo */
        .body-left .menu .menu-item .icon.report{
            background-image: url('../../../../assets/icon/report.png');
        }

        /* Danh mục nhân viên */
        .body-left .menu .menu-item .icon.employee-list{
            background-image: url('../../../../assets/icon/dic-employee.png');
        }

        /* Thiết lập hệ thống */
        .body-left .menu .menu-item .icon.setting{
            background-image: url('../../../../assets/icon/setting.png');
        }

        .body-left .menu .menu-item .item-name {
            width: 150px;
        }
</style>