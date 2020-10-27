<template>
  <div class="card">
    <router-link :to="{ name: 'Vault', params:{id:vaultData.id}}">
    <div class="card-body">
      <h4 class="card-title">{{vaultData.name}}</h4>
      <p class="card-text">{{vaultData.description}}</p>
    </div>
    </router-link>
  </div>
</template>

<script>
export default {
name:"vaultCard",
props:["vaultData"]
}
</script>

<style>

</style>