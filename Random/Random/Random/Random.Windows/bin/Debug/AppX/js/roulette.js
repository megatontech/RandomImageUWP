var characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
var getImageButton = document.getElementById("loadImage");
var randChars="";
var imageUrl="";
var tries = 0;

function newImage() {
    randChars = "";
    //document.getElementById("welcome").style.display="none";
    document.getElementById("image").style.opacity = "0";
    for(var i = 0;i<5;i++){
         randChars += characters.charAt(Math.floor(Math.random() * characters.length));
    }
    imageUrl = "http://i.imgur.com/"+randChars+".jpg";
    addImage(imageUrl);
}

function addImage(url) {
    document.getElementById("image").src = url;
}

function checkImage(){
    if(document.getElementById("image").width != 161){
        tries = 0;
        //document.getElementById("information").innerHTML = "";
        //getImageButton.innerHTML = "加载另一张";
        document.getElementById("image").style.opacity = "1";
        //document.getElementById("openImage").href = imageUrl;
        //document.getElementById("sidebar").innerHTML+="<a target='_blank' href='"+imageUrl+"'><img class='imagehistory' src='"+imageUrl+"'/></a>";
    }else {
        console.log("404'd");
        newImage();
        //document.getElementById("information").innerHTML = tries+" dead images";
        tries++;
    }
}
