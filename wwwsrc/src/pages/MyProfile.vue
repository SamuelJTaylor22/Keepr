<template>
  <main class="container-fluid mt-2">
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
          <div class="col-12"><h4>My Keeps <button type="button" class="btn btn-success" data-toggle="modal" data-target="#newKeep">New</button></h4> </div>
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
        <div class="modal fade" id="newKeep" tabindex="-1" role="dialog">
          <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">New Keep</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body row">
                <form @submit.prevent="addKeep">
                  <div class="form-group">
                    <label for="">Name</label>
                    <input v-model="newKeep.name" type="text" class="form-control" placeholder="" aria-describedby="helpId">
                    <label for="">Description</label>
                    <input v-model="newKeep.description" type="text" class="form-control" placeholder="" aria-describedby="helpId">
                    <label for="">Img URL</label>
                    <input v-model="newKeep.img" type="text" class="form-control" placeholder="" aria-describedby="helpId">
                    <button type="submit" class="btn btn-primary mt-1">Submit</button>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div> 
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
data(){
  return {
    newKeep:{
      name:"",
      description:"",
      img:""
    }
    
  }
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
  },
  addKeep(){
    this.$store.dispatch("createKeep", this.newKeep)
    $('#newKeep').modal('toggle')
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