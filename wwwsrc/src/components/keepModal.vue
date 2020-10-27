<template>
  <div class="">
        <div class="modal fade" id="keepModal" tabindex="-1" role="dialog">
          <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">{{activeKeep.name}}</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body row">
                <img class="img-fluid col-6" :src="activeKeep.img" alt="">
                <div class="col-6">
                  <h4>By: {{activeKeep.creator.name}}<img class="img-fluid" :src="activeKeep.creator.picture" alt=""></h4>
                  <p>Keeps: {{activeKeep.keeps}} Views: {{activeKeep.views}}</p>
                  <p>{{activeKeep.description}}</p>
                </div>
              </div>
              <div class="modal-footer">
                <button v-if="$auth.userInfo.id == activeKeep.creatorId && $route.name=='MyProfile'" type="button" class="btn btn-secondary" @click="deleteKeep" data-dismiss="modal">Delete</button>
                <button type="button" class="btn btn-primary">Keep It!</button>
              </div>
            </div>
          </div>
        </div> 
      </div>
</template>

<script>
export default {
name: "keepmodal",
computed:{
      activeKeep(){
      return this.$store.state.activeKeep
    }
},
methods:{
  deleteKeep(){
    this.$store.dispatch('deleteKeep', this.activeKeep.id)
  }
}
}
</script>

<style>

</style>