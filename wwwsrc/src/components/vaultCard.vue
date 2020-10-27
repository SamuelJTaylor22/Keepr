<template>
  <div class="card">
    <router-link :to="{ name: 'Vault', params:{id:vaultData.id}}">
    <div class="card-body">
      <h4 class="card-title">{{vaultData.name}}</h4>
      <p class="card-text">{{vaultData.description}}</p>
    </div>
    </router-link>
    <button type="button" @click="deleteVault" class="btn btn-danger">Delete</button>
  </div>
</template>

<script>
export default {
name:"vaultCard",
props:["vaultData"],
methods:{
  deleteVault(){
    this.$store.dispatch('deleteVault', this.vaultData.id)
  }
}
}
</script>

<style>

</style>