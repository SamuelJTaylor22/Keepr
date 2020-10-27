<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <h1 class="">Keepr</h1>
      </div>
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav">
        <!-- Consider changing this to a profile picture -->
        <li class="nav-item" :class="{active: $route.name == 'MyProfile'}">
          <router-link id="nav-myprofile link" :to="{name:'MyProfile'}" class="nav-link">
            My Profile
          </router-link>
        </li>
        <li v-if="!$auth.isAuthenticated">
        <button
          class="btn btn-success"
          @click="login"
        >
          Login
        </button>
        </li>
        <li v-else>
        <button class="btn btn-danger" @click="logout" >logout</button>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
import { getUserData } from "@bcwdev/auth0-vue";
import { setBearer, resetBearer } from "../services/AxiosService";
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      if (this.$auth.isAuthenticated) {
        setBearer(this.$auth.bearer);
        this.$store.dispatch("getProfile");
      }
    },
    async logout() {
      resetBearer();
      await this.$auth.logout({ returnTo: window.location.origin });
    },
  },
};
</script>

<style>
ul{
  list-style-type: none;
}
</style>
