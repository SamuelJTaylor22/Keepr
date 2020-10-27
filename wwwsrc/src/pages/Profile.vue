<template>
  <main class="container-fluid mt-2">
    <div class="row">
      <div class="col-12 col-md-4">
        <div class="card">
          <img class="card-img-top" :src="profile.picture" alt="">
          <div class="card-body">
            <h4 class="card-title">{{profile.name}}</h4>
            <p class="card-text">Keeps: {{keeps.length}} Vaults:{{vaults.length}}</p>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-4">
        <div class="row">
          <div class="col-12"><h4>Keeps</h4> </div>
          <div class="col-12 card-columns"><keep v-for="keep in keeps" :key="keep.id" :keepData="keep"  v-on:selected="toggleModal"/></div>
        </div>
      </div>
      <div class="col-12 col-md-4">
        <div class="row">
          <div class="col-12"><h4>Vaults</h4></div>
          <div class="col-12 card-columns"><vault v-for="vault in vaults" :key="vault.id" :vaultData="vault"  v-on:selected="toggleModal"/></div>
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
name:"profile",
mounted(){
  this.$store.dispatch("getProfileStuff", this.$route.params.id)
  this.$store.dispatch("getOtherProfile", this.$route.params.id)
},
computed: {
  profile(){
    return this.$store.state.otherProfile
  },
  keeps(){
    return this.$store.state.profileKeeps
  },
  vaults(){
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