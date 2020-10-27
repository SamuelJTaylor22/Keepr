<template>
  <div class="card">
    <div class="card-body">
      <h4 class="card-title">{{vaultData.name}}</h4>
      <p class="card-text">{{vaultData.description}}</p>
    </div>
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