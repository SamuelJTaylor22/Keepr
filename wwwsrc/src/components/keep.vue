<template>
  <div class="card" @click="setActive">
    <img class="card-img-top" :src="keepData.img" alt="Card image cap">
    <div class="card-body">
      <h5 class="card-title">{{keepData.name}}</h5>
      <p class="card-text">{{keepData.description}}</p>
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

</style>