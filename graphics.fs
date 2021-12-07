: .+  [char] + emit ;
: hline ( x y -- ) at-xy xdim 0 ?do .+ loop ;
: vline ( x y -- ) at-xy ydim 1+ 0 ?do .+ xdim i at-xy .+ cr loop ;
: draw-frame ( -- ) 0 0 hline 0 0 vline xdim 0 vline 0 ydim hline ;
: draw-snake ( -- ) length @ 0 ?do i segment 2@ at-xy ." #" loop ;
: draw-apple ( -- ) apple 2@ at-xy ." Q" ;

: render page draw-snake draw-apple draw-frame cr length ? ;
