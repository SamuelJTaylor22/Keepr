<template>
  <main class="container">
    <div class="row">
      <div class="col-12 col-md-4">
        <div class="card">
          <img class="card-img-top" :src="profile.picture" alt="">
          <div class="card-body">
            <h4 class="card-title">{{profile.name}}</h4>
            <p class="card-text">{{profile.email}}</p>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-4">
        <div class="row">
          <div class="col-12"><h4>My Keeps</h4></div>
          <div class="col-12 card-columns"><keep v-for="keep in myKeeps" :key="keep.id" :keepData="keep"  v-on:selected="toggleModal"/></div>
        </div>
      </div>
      <div class="col-12 col-md-4">
        <div class="row">
          <div class="col-12"><h4>My Vaults</h4></div>
          <div class="col-12 card-columns"><vault v-for="vault in myVaults" :key="vault.id" :vaultData="vault"  v-on:selected="toggleModal"/></div>
        </div>
      </div>
    </div>
    <keepModal/>
  </main>
</template>

<script>
import keep from '../components/keep'
import vault from '../components/vaultCard'
import keepModal from '../components/keepModal'
export default {
name:"myprofile",
mounted(){
  this.$store.dispatch("getProfileStuff", this.$auth.userInfo.id)
},
computed: {
  profile(){
    return this.$store.state.profile
  },
  myKeeps(){
    return this.$store.state.profileKeeps
  },
  myVaults(){
    return this.$store.state.profileVaults
  }
},  
methods: {
  toggleModal(){
    $('#keepModal').modal('show')
  }
},
components:{
  keep,
  keepModal,
  vault
}
}
</script>

<style>

</style>