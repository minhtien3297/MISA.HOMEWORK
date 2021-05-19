<template>
  <div id="tools">
    <!-- header -->
    <Header :Route="toolsRoute" />
  </div>
</template>

<script>
import Header from "../components/Layout/Header";

export default {
  components: { Header },

  computed: {
    toolsRoute() {
      return this.$store.getters.routeFilter("Công cụ dụng cụ");
    },
  },
};
</script>

<style></style>
