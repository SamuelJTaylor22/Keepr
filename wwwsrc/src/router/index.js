import Vue from "vue";
import VueRouter from "vue-router";
// @ts-ignore
import Home from "../pages/Home.vue";
// @ts-ignore
import MyProfile from "../pages/MyProfile.vue";
// @ts-ignore
import Profile from "../pages/Profile.vue";
// @ts-ignore
import Vault from "../pages/Vault.vue";
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/profile",
    name: "MyProfile",
    component: MyProfile,
    beforeEnter: authGuard
  },
  {
    path:"/profile/:id",
    name:"Profile",
    component: Profile
  },
  {
    path:"/vault/:id",
    name:"Vault",
    component: Vault
  }
];

const router = new VueRouter({
  routes,
});

export default router;
