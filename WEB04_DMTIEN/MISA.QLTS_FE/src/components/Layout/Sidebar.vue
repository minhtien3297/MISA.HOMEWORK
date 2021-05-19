<template>
  <div id="sidebar">
    <v-navigation-drawer
      v-model="drawer"
      :mini-variant.sync="mini"
      color="#011239"
      width="281"
      permanent
      app
    >
      <v-list-item class="px-2">
        <!-- logo web -->
        <v-list-item-avatar :class="{ 'logo-left': !mini }">
          <img src="../../assets/logo-qlts.svg" />
        </v-list-item-avatar>

        <!-- Tiêu đề web -->
        <v-list-item-title class="font-weight-bold text-h5"
          >QLTS.VN</v-list-item-title
        >

        <!-- button thu gọn sidebar -->
        <v-btn icon @click.stop="mini = !mini">
          <img src="../../assets/hamburger-menu.svg" />
        </v-btn>
      </v-list-item>

      <!-- Menu -->
      <v-list dense>
        <!-- hover để hiện submenu -->
        <v-menu open-on-hover offset-x v-for="item in menu" :key="item.text">
          <template v-slot:activator="{ on, attrs }">
            <!-- menu tài sản -->
            <v-list-item
              v-if="item.text == 'Tài sản'"
              v-bind="attrs"
              v-on="on"
              :class="{ 'menu-left': !mini }"
              :to="item.route"
              v-model="selectedItem"
              color="white"
              link
            >
              <!-- tiêu đề icon -->
              <v-list-item-icon :class="{ 'menu-arrow-close': mini }">
                <img :src="item.icon" />
              </v-list-item-icon>

              <v-list-item-content
                :class="{
                  'menu-arrow-open': !mini,
                }"
              >
                <v-list-item-title class="body-1">{{
                  item.text
                }}</v-list-item-title>
              </v-list-item-content>
            </v-list-item>

            <!-- list menu -->
            <v-list-item
              v-else
              :class="{ 'menu-left': !mini }"
              :to="item.route"
              v-model="selectedItem"
              color="white"
              link
            >
              <!-- Hiện mũi tên bên phải ở menu công cụ và danh mục -->
              <div
                v-if="item.text == 'Công cụ dụng cụ' || item.text == 'Danh mục'"
                class="d-flex"
              >
                <v-list-item-icon>
                  <img :src="item.icon" />
                </v-list-item-icon>

                <!-- tiêu đề icon -->
                <v-list-item-content
                  :class="{
                    'menu-arrow-open': !mini,
                    'menu-arrow-close': mini,
                  }"
                >
                  <v-list-item-title class="body-1">{{
                    item.text
                  }}</v-list-item-title>
                </v-list-item-content>
              </div>

              <!-- các menu còn lại -->
              <div v-else>
                <div class="d-flex">
                  <v-list-item-icon>
                    <img :src="item.icon" />
                  </v-list-item-icon>

                  <!-- tiêu đề icon -->
                  <v-list-item-content>
                    <v-list-item-title class="body-1">{{
                      item.text
                    }}</v-list-item-title>
                  </v-list-item-content>
                </div>
              </div>
            </v-list-item>
          </template>

          <!-- Submenu -->
          <v-list v-if="item.text == 'Tài sản'" id="submenu">
            <v-list-item
              v-for="(item, index) in submenu"
              :key="index"
              :to="item.route"
            >
              <v-list-item-title>{{ item.text }}</v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </v-list>
    </v-navigation-drawer>
  </div>
</template>

<script>
import { mapState } from "vuex";

export default {
  data() {
    return {
      drawer: true,

      mini: true,

      selectedItem: true,
    };
  },

  // Gán dữ liệu của menu từ store
  computed: mapState({
    menu: (state) => state.menu,
    submenu: (state) => state.submenu,
  }),
};
</script>

<style>
/* kéo nội dung trong menu sang bên phải khi mở rộng sidebar */
.menu-left {
  padding-left: 38px !important;
}

/* kéo nội dung ở logo sang bên phải khi mở rộng sidebar */
.logo-left {
  margin-left: 25px;
}

/* màu chữ tiêu đề */
#sidebar .v-list-item__title {
  color: #f5f5f5;
}

/* logo */
#sidebar .v-list-item__avatar img {
  height: 35px !important;
  max-width: 45px !important;
}

/* nút thu nhỏ sidebar */
#sidebar .v-btn__content img {
  height: 20px;
  max-width: 25px;
  margin-right: 25px;
}

/* Menu */
#sidebar .v-list .v-list-item {
  margin-bottom: 10px;
}

/* submenu */
.v-menu__content {
  min-width: 281px !important;
}

/* hiệu ứng màu khi trỏ vào của menu */
#sidebar .v-list .v-list-item:hover {
  background-image: linear-gradient(
    to right,
    #00abfe 0%,
    #00abfe 6px,
    #273557 6px,
    #273557 100%
  );
}

/* mũi tên khi mở menu */
#sidebar .v-list:hover .menu-arrow-open::after {
  content: "";
  position: absolute;
  top: 15px;
  right: 29px;
  width: 0;
  height: 0;
  border-top: 5px solid transparent;
  border-left: 5px solid white;
  border-bottom: 5px solid transparent;
}

#sidebar .v-list .v-list-item:hover .menu-arrow-open::after {
  border-left: 5px solid #00abfe;
}

/* mũi tên khi đóng menu*/
#sidebar .v-list:hover .menu-arrow-close::after {
  content: "";
  position: absolute;
  top: 33px;
  right: 1px;
  width: 0;
  height: 0;
  border-top: 7px solid transparent;
  border-right: 5px solid white;
  border-bottom: -3px solid transparent;
}

#sidebar .v-list .v-list-item:hover .menu-arrow-close::after {
  border-right: 5px solid #00abfe;
}

/* icon */
#sidebar .v-list-item__icon img {
  height: 25px;
  max-width: 25px;
}
</style>
