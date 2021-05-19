<template>
  <div class="header">
    <!-- dropdown-->
    <div class="dropdown">
      <!-- dropdown button -->
      <div class="dropbtn">
        <h3>Nhà hàng Biển Đông</h3>
        <p><i class="arrow-down"></i></p>
      </div>

      <!-- dropdown content -->
      <div class="dropdown-content">
        <h3>Nhà hàng 1</h3>
        <h3>Nhà hàng 2</h3>
        <h3>Nhà hàng 3</h3>
      </div>
    </div>

    <!-- user info -->
    <user-info></user-info>
  </div>
</template>

<script>
import userInfo from './user-info.vue';

export default {
  components: { userInfo },};
</script>

<style>
/* header */
.body-right .header {
    width: 100%;
    height: 50px;
    display: flex;
}

    /* dropdown */
    .body-right .header .dropdown{
        width: 170px;
        padding: 0px 0px 0px 30px;
    }
        /* dropdown button */
        .body-right .header .dropdown .dropbtn{
            display: flex;
            align-items: center;
            cursor: pointer;
        }

            /* mũi tên xuống */
            .body-right .header .dropdown .dropbtn .arrow-down{
                border: solid black;
                border-width: 0 3px 3px 0;
                display: inline-block;
                padding: 3px;
                transform: rotate(45deg);
                -webkit-transform: rotate(45deg);
                margin: 5px 10px;
            }

        /* dropdown content */
        .body-right .header .dropdown .dropdown-content{
            display: none;
            position: absolute;
            background-color: #f9f9f9;
            min-width: 170px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }

        .body-right .header .dropdown .dropdown-content h3{
            color: black;
            padding: 12px 16px;
            text-decoration: none;
            display: block;
        }

        /* Hiệu ứng trỏ vào dropdown */
        .body-right .header .dropdown:hover .dropdown-content{
            display: block;
        }

        .body-right .header .dropdown:hover .dropbtn{
            background: #DADCE0;
        }

        .body-right .header .dropdown-content h3:hover{
            background: #DADCE0;
        }
</style>