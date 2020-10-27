<template>
  <div class="home container">
    <div class="row">
      <div class="card-columns col-12">
        <keep v-for="keep in keeps" :key="keep.id" :keepData="keep"  v-on:selected="toggleModal"/>
      </div>
      <div class="col-12" v-if="activeKeep != {}">
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
                <!-- <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button> -->
                <button type="button" class="btn btn-primary">Keep It!</button>
              </div>
            </div>
          </div>
        </div> 
      </div>
    </div>
  </div>
  <!-- data-toggle="modal" data-target="#keepModal" -->
</template>

<script>
import keep from '../components/keep'
export default {
  name: "home",
  mounted(){
    this.$store.dispatch("getKeeps")
  },
  computed: {
    keeps(){
      return this.$store.state.keeps
    },
    activeKeep(){
      // $('#keepModal').modal('toggle')
      return this.$store.state.activeKeep
    }
  },
  components: {
    keep
  },
  methods: {
    setActive(id){
      this.$store.dispatch("setActiveKeep", id)
      $('#keepModal').modal('show')
    },
    toggleModal(){
      $('#keepModal').modal('show')
    }
  }
};
</script>
