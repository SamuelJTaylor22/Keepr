<template>
  <div class="container">
    <div class="row" v-if="vault != {}">
      <div class="col-12"><h1>{{vault.name}}</h1><h5>{{vault.description}}</h5></div>
      <div class="card-columns col-12">
        <keep v-for="keep in keeps" :key="keep.id" :keepData="keep"  v-on:selected="toggleModal" />
      </div>
      <keepModal v-on:remove="removeKeep"/>
    </div>
    <div v-else>
      <router-link :to="{name:'Home'}">You navigated to a vault that doesn't exist, or a private vault you don't own. Click here to go back home. </router-link>
    </div>
  </div>
</template>

<script>
import keep from '../components/keep'
import keepModal from '../components/keepModal'
export default {
name:"vault",
mounted(){
  this.$store.dispatch("getVault", this.$route.params.id)
  this.$store.dispatch("getVaultKeeps", this.$route.params.id)
},
computed :{
  vault(){
    return this.$store.state.activeVault
  },
  keeps(){
    return this.$store.state.vaultKeeps
  }
},
methods:{
  toggleModal(){
    $('#keepModal').modal('show')
  },
  removeKeep(id){
    let keep = this.keeps.find(k => k.id = id)
    this.$store.dispatch("removeKeepFromVault", keep)
    $('#keepModal').modal('toggle')
  }
},
components:{
  keep,
  keepModal
}
}
</script>

<style>

</style>