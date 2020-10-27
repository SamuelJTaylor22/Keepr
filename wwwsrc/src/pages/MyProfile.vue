<template>
  <main class="container">
    <div class="row">
      <div class="col-6">
        <div class="card">
          <img class="card-img-top" :src="profile.picture" alt="">
          <div class="card-body">
            <h4 class="card-title">{{profile.name}}</h4>
            <p class="card-text">{{profile.email}}</p>
          </div>
        </div>
      </div>
      <div class="col-6"></div>
    </div>
  </main>
</template>

<script>
export default {
name:"myprofile",
computed: {
  profile(){
    return this.$store.state.profile
  }
}
}
</script>

<style>

</style>