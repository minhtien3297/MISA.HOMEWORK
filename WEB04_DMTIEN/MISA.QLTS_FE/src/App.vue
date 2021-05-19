<template>
  <v-app>
    <!-- side bar -->
    <Sidebar />

    <!-- content page -->
    <v-main>
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
import Sidebar from "./components/Layout/Sidebar";

export default {
  name: "App",
  components: { Sidebar },
};
</script>

<style>
.v-application {
  font-size: 13px;
  margin: 0px;
  padding: 0px;
  height: 100vh;
}

body::-webkit-scrollbar {
  display: none;
}
</style>