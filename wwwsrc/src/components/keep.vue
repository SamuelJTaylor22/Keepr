<template>
  <div class="card" @click="setActive">
    <img class="card-img-top" :src="keepData.img" alt="Card image cap">
    <div class="row justify-content-between align-middle">
      <h5 class="card-title col">{{keepData.name}}</h5>
      <img v-if="$route.name != 'MyProfile'" :src="keepData.creator.picture" class="col img-fluid pfp" alt="">
    </div>
  </div>
</template>

<script>
export default {
name: "keep",
props: ["keepData"],
computed:{
  activeKeep(){
    return this.$store.state.activeKeep
  }
},
methods:{
  setActive(){
    if(this.keepData.id != this.activeKeep.id){
      this.$store.dispatch("setActiveKeep", this.keepData.id)
    }
    this.$emit("selected")
  }
}
}
</script>

<style>
.pfp{
  height: 4em;
  width: 4em;
}
</style>