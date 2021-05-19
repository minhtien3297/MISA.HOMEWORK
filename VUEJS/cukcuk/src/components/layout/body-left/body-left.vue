<template>
  <div class="body-left">
    <Sidebar />

    <Menu />
  </div>
</template>

<script>
import Menu from "./content/menu.vue";
import Sidebar from './content/sidebar.vue';

export default {
  components: {
    Menu,
    Sidebar
  },
};
</script>

<style>
/* body left */
.body-left {
  background-color: #ffffff;
  width: 226px;
  height: 100%;
  border-right: 1px solid #bbbbbb;
  display: flex;
  flex-direction: column;
}
</style>