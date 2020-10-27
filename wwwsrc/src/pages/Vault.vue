<template>
  <div class="container">
    <div class="row" v-if="vault != {}">
      <div class="col-12"><h1>{{vault.name}}</h1><h5>{{vault.description}}</h5></div>
      <div class="card-columns col-12">
        <keep v-for="keep in keeps" :key="keep.id" :keepData="keep"  v-on:selected="toggleModal"/>
      </div>
      <keepModal/>
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
    return this.$store.state.keeps
  }
},
methods:{
  toggleModal(){
    $('#keepModal').modal('show')
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