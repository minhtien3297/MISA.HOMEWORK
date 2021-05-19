<template>
  <div id="app">
    <body-left />

    <body-right />
  </div>
</template>

<script>
import BodyLeft from "./components/layout/body-left/body-left.vue";
import BodyRight from "./components/layout/body-right/body-right.vue";

export default {
  name: "App",
  components: {
    BodyLeft,
    BodyRight,
  },
};
</script>

<style>
body {
  margin: 0px;
  padding: 0px;
  height: 100vh;
}

#app {
  font-family: MISA-Regular, MISA-Bold, MISA-Italic;
  font-size: 13px;
  margin: 0px;
  padding: 0px;
  height: 100vh;
}

/*font links*/
@font-face {
  font-family: "MISA-Regular";
  src: url("./assets/font/GoogleSans-Regular.otf") format("opentype");
}

@font-face {
  font-family: "MISA-Bold";
  src: url("./assets/font/GoogleSans-Bold.otf") format("opentype");
}

@font-face {
  font-family: "MISA-Italic";
  src: url("./assets/font/GoogleSans-Italic.otf") format("opentype");
}
</style>
