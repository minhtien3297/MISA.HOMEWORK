import Vue from "vue";
import VueRouter from "vue-router";
import Customer from "../views/customer.vue";
import Employee from "../views/employee.vue";

Vue.use(VueRouter);

const routes = [
  { path: "/customer",
    name: "Customer",
    component: Customer,
  },

  {
    path: "/employee",
    name: "Employee",
    component: Employee,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
