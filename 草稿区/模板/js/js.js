function $(id){
    return document.getElementById(id);
}
window.onload=function(){
    var target = 0;
    var leader =0;
    $('box').onmouseover=function(){
        $('arrow').style.display='block';
    }
    $('box').onmouseout=function(){
        $('arrow').style.display='none';
    }

    $('left').onclick=function(){
        target += 800;
    }
    $('right').onclick=function(){
        target -= 800;
    }
    setInterval(function(){
        if(target >= 0){
            target = 0;
        }
        else if(target <= -2400){
            target = -2400;
        }
        leader =leader +(target -leader) /10;
        $('ad_imgs').style.left=leader+'px';
    },30);
    
}

/*发布结伴封面图*/ 
function Click_input(){
    document.getElementById('Page2_caozuoquyu_input').addEventListener('change',function(e){
                var files = this.files;
                var img = new Image();
                var reader = new FileReader();
            reader.readAsDataURL(files[0]);
            reader.onload = function(){
               //img的定位
                img.src = this.result;
                img.setAttribute("id","Page2_caozuoquyu_tupian1");
                img.style.width = "350px";
                img.style.height= "200px";
                img.style.top="30";
                img.style.left="20";
                img.style.position='absolute';
                //添加img子节点 
            document.getElementById('Page2_caozuoquyu').appendChild(img);
            }
        });
    }