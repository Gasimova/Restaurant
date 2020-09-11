$(document).ready(function () {

    // $("#profile").click(function (e) {
    //     e.preventDefault();
    // });



    //social media plugin 
    var Id = $(".author").data("id")
    $("#shareBlock").cShare({
            showButtons: [
            'pinterest',
            'twitter'
            ],
            description: 'Fast Facts About Food , Recipies ,Cook',
            spacing: 5,
        shareToText: 'Share to',
        url: location.href
        });

   


    //navbar responsive codes
    $("#navbar-show").click(function () {

        $("#navbarNav").toggle();

    });

    $(window).resize(function () {
        if ($(this).outerWidth() > 768) {
            $(".myNav .collapse").css("display", "block");
        }
        else {
            $(".myNav .collapse").css("display", "none");
        }
    });

    if ($("#counter").length) {
        $('#counter .aboutCounter .key').counterUp({
            delay: 10,
            time: 1000
        });

    }

    if ($(".range").length) {
        $("#myRange").slider({
            min: 1,
            max: 50,
            step: 1,
        })
    }

    //add bag icon on click other icon css
    var count2 = 0;
    if ($("#menuList").length) {
        $("#menuList .cartIcon").click(function () {
            $(this).parent().parent().addClass("addedToBag");
            count2 += 1;
            $(".countOfProduct").text(count2);
        });
    }

    //add bag icon when click cart icon
    var count = 0;
    if ($("#discoverOurMenu").length) {
        $("#discoverOurMenu .cartIcon").click(function () {
            $(this).parent().parent().addClass("addedToBag");
            count += 1;
            $(".countOfProduct").text(count);
        });
    }


    //pagenation default color 
    if ($("#blogItems").length) {
        $(".page").click(function () {
            $(this).addClass("default").siblings().removeClass("default");

        })

        $(".prev").click(function () {
            if ($(".page").hasClass("default")) {
                $(".page").removeClass("default").next().addClass("default")
            }

        })

        $(".next").click(function () {
            if ($(".page").hasClass("default")) {
                $(".page").removeClass("default").next().addClass("default")
            }
        })
    }

    //subscribe with ajax
    $("#btnSubmit").click(function (e) {
        e.preventDefault();
        var obj = {
            Email : $("#Email").val()
        }

        $.ajax({
            url: "/Home/Subscribe",
            type: "post",
            data: obj,
            dataType: "JSON",
            success: function (response) {
                swal("Thank you", "for subscribing", "success");
            }
        });
    });

    //select menu 
    $("#orderby").change(function () {
        var catId = parseInt($(this).val())

        $.ajax({
            url: "/Shop/SelectMenu/" + catId,
            type: "get",
            dataType: "json",
            success: function (response) {
                var ul = $(".items ul");
                ul.empty();
                for (var i = 0; i < response.length; i++) {

                    var li = $("<li></li>");
                    var a = $("<a class='viewDetails'  href = '/Menu/Details/" + response[i].Id + "'</a>");
                    var image = $("<img src='/Uploads/" + response[i].Image + "'>");
                    var h = $("<h2>" + response[i].Name + "</h2>");
                    var p = $("<p>" + (response[i].Description.length > 50 ? response[i].Description.substr(0, 50) : response[i].Description) + "</p>");
                    var span = $("<span> $" + response[i].Price.toFixed(2) + "</span>");
                    var btn = $("<a class='addtoCart' data-id='" + response[i].Id + "'href='#'>add to cart</a>");

                    a.append(image);
                    a.append(h);
                    a.append(p);
                    a.append(span);
                    li.append(a);
                    li.append(btn);
                    ul.append(li);
                }

                //select menu add item to side cart and cookie
                $(".addtoCart").click(function (e) {
                    e.preventDefault()
                var Id = parseInt($(this).data("id"));
                var This = $(this);

                var innerCart = document.querySelector(".innerCart");

                $.ajax({
                    url: "/Shop/AddToCard/" + Id,
                    type: "get",
                    dataType: "json",
                    success: function (response) {
                        if (response.Response === "success-true") {
                            var oldCountTrue = parseInt($(".countOfProduct").text());
                            oldCountTrue++;
                            $(".countOfProduct").text(oldCountTrue);
                            This.addClass("addedToCard");
                            document.querySelector(".shoppingCart").style.display = "block";

                        }
                        else if (response.Response === "success-false") {
                            var oldCountFalse = parseInt($(".countOfProduct").text());
                            oldCountFalse--;
                            $(".countOfProduct").text(oldCountFalse);
                            This.removeClass("addedToCard");
                            if (oldCountFalse == 0) {
                                innerCart.style.display = "none";
                                document.querySelector(".shoppingCart").style.display = "none";

                            }
                        }

                        var shoppingCart = $(".cartItems")
                        shoppingCart.empty();

                        console.log(response)
                        for (var i = 0; i < response.Menu.length; i++) {
                            var innerCard = $(" <div class='innerCart'></div>")
                            var closeBtn = $("<i data-id=" + response.Menu[i].Id + " class='fas fa-times close'></i>")
                            var image = $("<img src='/Uploads/" + response.Menu[i].Image + "'>");
                            var h6 = $(" <h6>" + response.Menu[i].Name + "</h6>")
                            var span = $("<span> 1 x $" + response.Menu[i].Price + "</span>")

                            innerCard.append(closeBtn);
                            innerCard.append(image);
                            innerCard.append(h6);
                            innerCard.append(span);
                            shoppingCart.append(innerCard);
                        }
                    },
                    error: function (error) {
                        console.log(error);
                    }
                });
                })
            },
            error: function (error) {
                console.log("error")
            }

        })



    });

    //shopping card
    $(".addtoCart").click(function (e) {
        e.preventDefault();
        var Id = parseInt($(this).data("id"));
        var This = $(this);

        var innerCart = document.querySelector(".innerCart");

        $.ajax({
            url: "/Shop/AddToCard/" + Id,
            type: "get",
            dataType: "json",
            success: function (response) {
                if (response.Response === "success-true") {
                    var oldCountTrue = parseInt($(".countOfProduct").text());
                    oldCountTrue++;
                    $(".countOfProduct").text(oldCountTrue);
                    This.addClass("addedToCard");
                    document.querySelector(".shoppingCart").style.display = "block";

                }
                else if (response.Response === "success-false") {
                    var oldCountFalse = parseInt($(".countOfProduct").text());
                    oldCountFalse--;
                    $(".countOfProduct").text(oldCountFalse);
                    This.removeClass("addedToCard");
                    if (oldCountFalse == 0) {
                        innerCart.style.display = "none";
                        document.querySelector(".shoppingCart").style.display = "none";

                    } 
                }

                var shoppingCart = $(".cartItems")
                shoppingCart.empty();

                console.log(response)
                for (var i = 0; i < response.Menu.length; i++) {
                    var innerCard = $(" <div class='innerCart'></div>")
                    var closeBtn = $("<i data-id=" + response.Menu[i].Id + " class='fas fa-times close'></i>")
                    var image = $("<img src='/Uploads/" + response.Menu[i].Image + "'>");
                    var h6 = $(" <h6>" + response.Menu[i].Name + "</h6>")
                    var span = $("<span> 1 x $" + response.Menu[i].Price + "</span>")

                    innerCard.append(closeBtn);
                    innerCard.append(image);
                    innerCard.append(h6);
                    innerCard.append(span);
                    shoppingCart.append(innerCard);
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    //remove product from side product list in shop page and cookie 
    $(".close").click(function (e) {
        e.preventDefault()
        var Id = parseInt($(this).data("id"));

        console.log(Id)

        $(this).parent().remove();
        var oldCountFalse = parseInt($(".countOfProduct").text());
        oldCountFalse--;
        $(".addtoCart").removeClass("addedToCard")

        $(".countOfProduct").text(oldCountFalse);
        

        $.ajax({
            url: "/Shop/RemoveFromCookie/" + Id,
            type: "get",
            dataType: "json",
            success: function (response) {

            },
            error: function (error) {
                console.log(error);
            }
        });
        if ($(".countOfProduct").text()==0) {
            document.querySelector(".noItem").style.display = "block";
        }


    });

    //change product count in card page
    $(".countProduct").change(function () {
        var count = $(this).val()
        var price = parseFloat($(this).data("price"))
        var Id = parseInt($(this).data("id"))

        //one product total price
        $(".priceTotal"+Id+"").text("$" + (count * price).toFixed(2));

        // all product list price 
        var inputs = $(".countProduct");
        var total = 0;

        for (var i = 0; i < inputs.length; i++) {
            total += parseFloat(inputs[i].value) * parseFloat(inputs[i].dataset.price)
        }

        $(".totalPrice").text("$" + total.toFixed(2));

    });

    //remove item from Card
    $(".removeBtn").click(function (e) {
        e.preventDefault()
        var Id = parseInt($(this).data("id"));

        //remove element from card and cookie
        $(this).parent().parent().remove();
        var oldCountFalse = parseInt($(".countOfProduct").text());
        oldCountFalse--;
        $(".countOfProduct").text(oldCountFalse);

        $.ajax({
            url: "/Shop/RemoveFromCookie/" + Id,
            type: "get",
            dataType: "json",
            success: function (response) {
                console.log(response);
            },
            error: function (error) {
                console.log(error);
            }
        });

        //decrease total price
        var inputs = $(".countProduct");
        var total = 0;

        for (var i = 0; i < inputs.length; i++) {
            total += parseFloat(inputs[i].value) * parseFloat(inputs[i].dataset.price)
        }

        $(".totalPrice").text("$" + total.toFixed(2));
    })

    //confirm order
    $(".PlaceOrder").click(function (e) {
        e.preventDefault()

        var arr = [];
        var arrQuantity = [];
        var productId = $(".productId");
        var productQuantity = $(".productQuantity");
        for (var i = 0; i < productId.length; i++) {
            arr.push(productId[i].value);
            arrQuantity.push(productQuantity[i].value);
            console.log(arr)
            console.log(arrQuantity)
        }

        var obj = {
            Name: $("#name").val(),
            Surname: $("#lastName").val(),
            Address: $("#address").val(),
            Phone: $("#phone").val(),
            Email: $("#email").val(),
            ProductId: arr,
            ProductQuantity: arrQuantity
        }




        $.ajax({
            url: "/Checkout/PlaceOrder",
            type: "POST",
            data: obj,
            dataType: "JSON",
            success: function (response) {
                swal("Thank you", "for your order", "success");
                //var oldCountTrue = parseInt($(".countOfProduct").text());
                //oldCountTrue="0";
                //$(".countOfProduct").text(oldCountTrue);
            },
            error: function (error) {
                console.log(error)
            }
        })
    })
    
    // menu categories filter in shop page
    $(".menuCat").click(function (e) {
        e.preventDefault()
        var id = parseInt($(this).data("id"))
        console.log(id)

        $.ajax({
            url: "/Shop/SelectMenu/" + id,
            type: "get",
            dataType: "json",
            success: function (response) {
                var ul = $(".items ul");
                    ul.empty();

                for (var i = 0; i < response.length; i++) {
                    var li = $("<li></li>");
                    var a = $("<a class='viewDetails'  href = '/Menu/Details/" + response[i].Id + "'</a>");
                    var image = $("<img src='/Uploads/" + response[i].Image + "'>");
                    var h = $("<h2>" + response[i].Name + "</h2>");
                    var p = $("<p>" + (response[i].Description.length > 50 ? response[i].Description.substr(0, 50) : response[i].Description) + "</p>");
                    var span = $("<span> $" + response[i].Price.toFixed(2) + "</span>");
                    var btn = $("<a onclick='cart()' class='addtoCart' data-id=" + response[i].Id + "href='#'>add to cart</a>");

                    a.append(image);
                    a.append(h);
                    a.append(p);
                    a.append(span);
                    li.append(a);
                    li.append(btn);
                    ul.append(li);
                }
            },
            error: function (error) {
                console.log("error")
            }

        })



    });

    //menu categories filter in home page 
    $(".menuCat").click(function (e) {
        e.preventDefault()
        var id = parseInt($(this).data("id"))

        $.ajax({
            url: "/Shop/SelectMenu/" + id,
            type: "get",
            dataType: "json",
            success: function (response) {
                var customRor = $("#discoverOurMenu .customRow");
                customRor.empty();

                for (var i = 0; i < response.length; i++) {
                    var colClass = $("<div class='col-lg-3 col-md-6 col-sm-6'></div>");
                    var listItem2 = $(" <div class='listItem2'></div>");
                    var image2 = $(" <div class='image2'></div>");
                    var image = $("<a href='/Menu/Details/" + response[i].Id + "'>" + "<img src='/Uploads/" + response[i].Image + "'>" + "</a>");
                    var overlay = $("<div class='overlay'></div>");
                    var cartIcon = $(" <div class='cartIcon'></div>");
                    var bagIcon = $(" <div class='bagIcon'></div>");
                    var addToCart = $("<a class='addtoCart'" + response[i].Id + "href=>" + "<i class='fas fa-shopping-bag'></i></a>");
                    var info2 = $("<div class='info2'></div>");
                    var title = $("<a href = '/Menu/Details/" + response[i].Id + "'</a>")
                    var h5 = $("<h5>" + response[i].Name + "</h5>");
                    var p = $("<p>" + (response[i].Description.length > 50 ? response[i].Description.substr(0, 50) : response[i].Description) + "</p>");
                    var price = $("<span class='price'>$" + response[i].Price.toFixed(2) + "</span>");

                    bagIcon.append(addToCart);
                    overlay.append(cartIcon);
                    overlay.append(bagIcon);
                    image2.append(image);
                    image2.append(overlay);
                    listItem2.append(image2);
                  
                    title.append(h5);
                    info2.append(title);
                    info2.append(p);
                    info2.append(price);
                    listItem2.append(image2);
                    listItem2.append(info2);

                    colClass.append(listItem2);
                    customRor.append(colClass)


                }
            },
            error: function (error) {
                console.log("error")
            }

        })
    });

    //menu categories filter in menu page 
    $(".menuCat").click(function (e) {
        e.preventDefault()
        var id = parseInt($(this).data("id"))

        $.ajax({
            url: "/Shop/SelectMenu/" + id,
            type: "get",
            dataType: "json",
            success: function (response) {
                var customRow = $("#menuList .productList .customRow");
                customRow.empty();

                var menuResponse = (response.length - response.length) + 6;

                for (var i = 0; i < menuResponse; i++) {
                    var colClass = $("<div class=' col-md-6 col-lg-6'></div>");
                    var listItem2 = $(" <div class='listItem'></div>");
                    var image2 = $(" <div class='image'></div>");
                    var image = $("<a href='/Menu/Details/" + response[i].Id + "'>" + "<img src='/Uploads/" + response[i].Image + "'>" + "</a>");
                    var overlay = $("<div class='overlay'></div>");
                    var cartIcon = $(" <div class='cartIcon'></div>");
                    var bagIcon = $(" <div class='bagIcon'></div>");
                    var addToCart = $("<a class='addtoCart'" + response[i].Id + "href=>" + "<i class='fas fa-shopping-bag'></i></a>");
                    var info2 = $("<div class='info'></div>");
                    var title = $("<a href = '/Menu/Details/" + response[i].Id + "'</a>")
                    var h5 = $("<h5>" + response[i].Name + "</h5>");
                    var p = $("<p>" + (response[i].Description.length > 50 ? response[i].Description.substr(0, 50) : response[i].Description) + "</p>");
                    var price = $("<span class='price'>$" + response[i].Price.toFixed(2) + "</span>");

                    bagIcon.append(addToCart);
                    overlay.append(cartIcon);
                    overlay.append(bagIcon);
                    image2.append(image);
                    image2.append(overlay);
                    listItem2.append(image2);

                    title.append(h5);
                    info2.append(title);
                    info2.append(p);
                    info2.append(price);
                    listItem2.append(image2);
                    listItem2.append(info2);

                    colClass.append(listItem2);
                    customRow.append(colClass)

                }
            },
            error: function (error) {
                console.log("error")
            }

        })
    });

    //view all menu in menu page 
    $(".viewAll").click(function (e) {
        e.preventDefault()
        var id = parseInt($(".menuCat").data("id"))

        $.ajax({
            url: "/Shop/SelectMenu/" + id,
            type: "get",
            dataType: "json",
            success: function (response) {
                var customRow = $("#menuList .productList .row");
                customRow.empty();

                for (var i = 0; i < response.length; i++) {
                    var colClass = $("<div class=' col-md-6 col-lg-6'></div>");
                    var listItem2 = $(" <div class='listItem'></div>");
                    var image2 = $(" <div class='image'></div>");
                    var image = $("<a href='/Menu/Details/" + response[i].Id + "'>" + "<img src='/Uploads/" + response[i].Image + "'>" + "</a>");
                    var overlay = $("<div class='overlay'></div>");
                    var cartIcon = $(" <div class='cartIcon'></div>");
                    var bagIcon = $(" <div class='bagIcon'></div>");
                    var addToCart = $("<a class='addtoCart'" + response[i].Id + "href=>" + "<i class='fas fa-shopping-bag'></i></a>");
                    var info2 = $("<div class='info'></div>");
                    var title = $("<a href = '/Menu/Details/" + response[i].Id + "'</a>")
                    var h5 = $("<h5>" + response[i].Name + "</h5>");
                    var p = $("<p>" + (response[i].Description.length > 50 ? response[i].Description.substr(0, 50) : response[i].Description) + "</p>");
                    var price = $("<span class='price'>$" + response[i].Price.toFixed(2) + "</span>");

                    bagIcon.append(addToCart);
                    overlay.append(cartIcon);
                    overlay.append(bagIcon);
                    image2.append(image);
                    image2.append(overlay);
                    listItem2.append(image2);

                    title.append(h5);
                    info2.append(title);
                    info2.append(p);
                    info2.append(price);
                    listItem2.append(image2);
                    listItem2.append(info2);

                    colClass.append(listItem2);
                    customRow.append(colClass)

                }
            },
            error: function (error) {
                console.log("error")
            }

        })
    });

    // show messages in blog details
    $("#blogForm").submit(function () {
        var blogId = parseInt($(".blog").val())
        console.log(blogId)

        $.ajax({
            url: "/Blogs/GetMessage/" + blogId,
            type: "get",
            dataType: "json",
            success: function (response) {
                var comments = $(".comments")
                for (var i = 0; i < response.length; i++) {

                    var innerComment = $("<div class=innerComment></div>");
                    var left = $("<div class=left></div>");
                    var image = $(" <img src='~/Public/img / download.jpg'>");
                    var h6 = $("<h6></h6>");
                    var p = $("<p>" + response[i].Comment + "</p>")

                    left.append(image);
                    left.append(h6);
                    innerComment.append(left);
                    innerComment.append(p)

                    comments.append(innerComment);
                }

            },
            error: function (error) {
                console.log(error)
            }
        });


    });
   
    // price filter in shop page
    $("#filterBtn").click(function (e) {
        e.preventDefault()
        var price = parseFloat($("#myRange").val())

        console.log(price)

        $.ajax({
            url: "/Shop/PriceFilter?price=" + price,
            type: "get",
            dataType: "json",
            success: function (response) {
                var ul = $(".items ul");
                ul.empty();

                for (var i = 0; i < response.length; i++) {

                    var li = $("<li></li>");
                    var a = $("<a class='viewDetails'  href = '/Menu/Details/" + response[i].Id + "'</a>");
                    var image = $("<img src='/Uploads/" + response[i].Image + "'>");
                    var h = $("<h2>" + response[i].Name + "</h2>");
                    var p = $("<p>" + (response[i].Description.length > 50 ? response[i].Description.substr(0, 50) : response[i].Description) + "</p>");
                    var span = $("<span> $" + response[i].Price.toFixed(2) + "</span>");
                    var btn = $("<a  class='addtoCart' data-id='" + response[i].Id + "'href='#'>add to cart</a>");

                    a.append(image);
                    a.append(h);
                    a.append(p);
                    a.append(span);
                    li.append(a);
                    li.append(btn);
                    ul.append(li);
                }


                //Pagination
                var pageNav = $(".pageNav");
                pageNav.empty();

                var  pageCount = Math.ceil(response.length / 12);
                console.log(pageCount)
                var currentPage = 1;

                var left = $("<a class='prev' href='/Shop/Index?page=1' >" + "<i class='fas fa-angle-double-left'></a>")
                for (var i = 1; i <= pageCount.length; i++) {
                    if (i == currentPage) {
                        var defaultPage = $("<a class='page default' href='#'>" + pageCount[i] + "</a>")

                    } else {
                        var page = $("<a class='page' href='/Shop/Index?page=" + pageCount[i] + "'>" + i + "</a>")
                    }
                };
                var right = $("<a class='next' href ='/Shop/Index?page=" + (currentPage + 1) + "'>" + "<i class='fas fa-angle-double-right'></a>")

                pageNav.append(left);
                pageNav.append(defaultPage);
                pageNav.append(page);
                pageNav.append(right);


                //select menu add item to side cart and cookie
                $(".addtoCart").click(function (e) {
                    e.preventDefault()
                    var Id = parseInt($(this).data("id"));
                    var This = $(this);

                    var innerCart = document.querySelector(".innerCart");

                    $.ajax({
                        url: "/Shop/AddToCard/" + Id,
                        type: "get",
                        dataType: "json",
                        success: function (response) {
                            if (response.Response === "success-true") {
                                var oldCountTrue = parseInt($(".countOfProduct").text());
                                oldCountTrue++;
                                $(".countOfProduct").text(oldCountTrue);
                                This.addClass("addedToCard");
                                document.querySelector(".shoppingCart").style.display = "block";

                            }
                            else if (response.Response === "success-false") {
                                var oldCountFalse = parseInt($(".countOfProduct").text());
                                oldCountFalse--;
                                $(".countOfProduct").text(oldCountFalse);
                                This.removeClass("addedToCard");
                                if (oldCountFalse == 0) {
                                    innerCart.style.display = "none";
                                    document.querySelector(".shoppingCart").style.display = "none";

                                }
                            }

                            var shoppingCart = $(".cartItems")
                            shoppingCart.empty();

                            console.log(response)
                            for (var i = 0; i < response.Menu.length; i++) {
                                var innerCard = $(" <div class='innerCart'></div>")
                                var closeBtn = $("<i data-id=" + response.Menu[i].Id + " class='fas fa-times close'></i>")
                                var image = $("<img src='/Uploads/" + response.Menu[i].Image + "'>");
                                var h6 = $(" <h6>" + response.Menu[i].Name + "</h6>")
                                var span = $("<span> 1 x $" + response.Menu[i].Price + "</span>")

                                innerCard.append(closeBtn);
                                innerCard.append(image);
                                innerCard.append(h6);
                                innerCard.append(span);
                                shoppingCart.append(innerCard);
                            }
                        },
                        error: function (error) {
                            console.log(error);
                        }
                    });
                })

            },
            error: function (error) {
                console.log("error")
            }
        })
    });

    // user settings
    $(".userSetting").click(function () {
        var Id = $(this).data("id")
        console.log(Id)

        $.ajax({
            url: "/Home/GetUserInfo/" + Id,
            type: "get",
            dataType: "json",
            success: function (response) {

                var form = $(".billingDetails form");
                form.empty();

                for (var i = 0; i < response.length; i++) {
                    var lblName = $("<label class='name' for='name'>First name *</label>");
                    var inputName = $("<input class='custom' id='name' type='text' name = 'Name'" + response[i].Name + ">");

                    var lblSurName = $("<label class='name' for='lastName'>Last name *</label>");
                    var inputSurname = $("<input class='custom' id='lastName' type='text' name='Surname'" + response[i].Surname + ">");

                    var lblUsername = $("<label  for='username'>Username *</label>");
                    var inputUsername = $("<input  id='username' type='text' name='Username'" + response[i].Username + ">");

                    var lblAddress = $("<label  for='address'>Address *</label>");
                    var inputAddress = $("<input  id='address' type='text' name='Address'" + response[i].Address + ">");

                    var lblPassword = $("<label for='password'>Password *</label>");
                    var inputPassword = $(" <input type='text' id='password' name='Password'>");

                    var lblRepeatPassword = $("<label for='RepeatPassword'>Repeat Password *</label>");
                    var inputRepeatPassword = $(" <input type='text' id='RepeatPassword' name='RepeatPassword'>");

                    var lblPhone = $(" <label for='phone'>Phone *</label>");
                    var inputPhone = $(" <input id='phone' type='number' name='RepeatPassword'" + response[i].Phone + ">");

                    var lblEmail = $("<label for='email'>Email address *</label>");
                    var inputEmail = $(" <input id='email' type='email'  name='Phone'" + response[i].Email + ">");

                    form.append(lblName);
                    form.append(inputName);

                    form.append(lblSurName);
                    form.append(inputSurname);

                    form.append(lblUsername);
                    form.append(inputUsername);

                    form.append(lblAddress);
                    form.append(inputAddress);

                    form.append(lblPassword);
                    form.append(inputPassword);

                    form.append(lblRepeatPassword);
                    form.append(inputRepeatPassword);

                    form.append(lblPhone);
                    form.append(inputPhone);

                    form.append(lblEmail);
                    form.append(inputEmail);
                }


            },
            error: function (error) {
                console.log(error)
            }
        });
    })


    //user orders
    $(".userOrders").click(function () {
        var Id = $(this).data("id")
        console.log(Id)

        $.ajax({
            url: "/Home/GetUserOrders/" + Id,
            type: "get",
            dataType: "json",
            success: function (response) {
                console.log(response)
                var productTable = $("#orders .bodyOfTable");
                var table = $(".productTable");
                productTable.empty();

                for (var i = 0; i < response.length; i++) {
                    var rowBody = $(" <tr class='rowBody'></tr>")
                    var tdRemoveProduct = $("  <td class='removeProduct'></td>");
                    var span = $(" <span>" + response[i].CreatedDate + "</span>");

                    var tdImage = $("  <td class='imgProduct'></td>");
                    var image = $("  <a href='#'><img src='/Uploads/" + response[i].Image + "'alt=''></a>");

                    var tdName = $("  <td class='name'></td>");
                    var name = $(" <a href='#'>" + response[i].Menu.Name + "</a>");

                    var tdPrice = $(" <td class='priceProduct'></td>");
                    var price = $("  <span> $" + response[i].Menu.Price + "</span>");

                    var tdQuatity = $(" <td class='quantityProduct'></td>");
                    var quantity = $(" <span class='quantity'>0</span> ");

                    var tdTotal = $("<td class='totalProduct'></td>");
                    var total = $(" <h6> $" + response[i].Price + "</h6>")


                    tdRemoveProduct.append(span);
                    tdImage.append(image);
                    tdName.append(name);
                    tdPrice.append(price);
                    tdQuatity.append(quantity);
                    tdTotal.append(total);

                    rowBody.append(tdRemoveProduct);
                    rowBody.append(tdImage);
                    rowBody.append(tdName);
                    rowBody.append(tdPrice);
                    rowBody.append(tdQuatity);
                    rowBody.append(tdTotal);

                    productTable.append(rowBody);
                    table.append(productTable);
                    //tBody.append(rowBody)
                }

               


            },
            error: function (error) {
                console.log(error)
            }
        });
    });

   // active nav link
    //if ($("header").length) {
    //    var nav = $("header .nav-item");
    //    $("header .nav-item").click(function () {
    //        if ($(this).hasClass("activeNav")) {
    //            $(this).removeClass("activeNav");
    //            $(this).addClass("activeNav");
    //        } else {
    //            $(this).addClass("activeNav");
    //            $(this).siblings().removeClass("activeNav");
    //        }

    //     })
    //}


});




//datetimepicker for reservation
const reservation = document.querySelector("#reservation");
if (reservation != null) {
    rome(dt);
}


//booknow btn click go to reservation in about page
const bookBtn = document.querySelector(".book");
var weAreVincent = document.querySelector("#weAreVincent");
if (weAreVincent!= null) {
    bookBtn.addEventListener("click", function (e) {
        e.preventDefault()
        window.scrollTo(0, 4300);
        bookBtn.style.transition = "all 1s linear";
    });
}

//go top button
const goTop = document.querySelector("#goTopBtn .goTop");
if (goTop != null) {
    window.addEventListener("scroll", function () {
        if (window.pageYOffset > 750) {
            goTop.style.display = "block";
        } else {
            goTop.style.display = "none";
        }
    })
}

//back to window default scroll
if (goTop != null) {
    goTop.addEventListener("click", function () {
        window.scrollTo(0, 0);
    })
}


//open image in icon click
function openImage(e) {
    document.querySelector(".mySlide").style.display = "block";
    document.querySelector(".mySlide").style.zIndex = "500";
    document.querySelector(".bg").style.display = "block"
    document.querySelector(".mySlide").style.transform = "scale(1)";
    document.querySelector(".mySlide").style.transition = "all 3s";


    var dataIndex = parseInt(e.target.dataset.index);
    console.log(dataIndex)
    var slides = document.querySelectorAll(".slideInner img");

    var activeImage = document.querySelector("#imageGalery .mySlide .aboutSlide .slideInner .active");
    if (activeImage != null) {
        activeImage.classList.remove("active");
    }

    for (let i = 0; i < slides.length; i++) {
        if (parseInt(slides[i].dataset.index) == dataIndex) {
            slides[i].classList.add("active");
        }
    }
}

//close image in lightbox
function closeImage() {
    document.querySelector(".mySlide").style.display = "none"
    document.querySelector(".bg").style.display = "none"
}

//slider in about page when click plus sign
var slide = document.querySelectorAll(".slideInner img");
var prev = document.querySelector(".leftArrow ");
var next = document.querySelector(".rightArrow ");
var imageGalery = document.querySelector("#imageGalery");
var number = document.querySelector(".slideNumber")
var currentPosition = 0;
var leftDirection = 0;

if (imageGalery != null) {
    next.addEventListener("click", function () {
        var activeImage = document.querySelector("#imageGalery .mySlide .aboutSlide .slideInner .active");
        if (activeImage.nextElementSibling == null) {
            slide[0].classList.add("active");

        } else {
            activeImage.nextElementSibling.classList.add("active");
        }
        activeImage.classList.remove("active");

    });
}

if (imageGalery != null) {
    prev.addEventListener("click", function () {
        var activeImage = document.querySelector("#imageGalery .mySlide .aboutSlide .slideInner .active");
        if (activeImage.previousElementSibling == null) {
            slide[slide.length - 1].classList.add("active");

        } else {
            activeImage.previousElementSibling.classList.add("active");
        }
        activeImage.classList.remove("active");


    });
}




//show password
function showPsw()   {
    var pswInput = document.querySelector(".show .long");
    var eye = document.querySelector(".fa-eye");
    var eyeSlash = document.querySelector(".fa-eye-slash");
    if (pswInput.type === "password") {
        pswInput.type = "text"
        eye.style.opacity = "0"
        eyeSlash.style.opacity = "1"

    } else {
        pswInput.type = "password"
        eye.style.opacity = "1"
        eyeSlash.style.opacity = "0"
    }
}

function showPsw2() {
    var pswInput2 = document.querySelector(".show2 .long");
    var eye = document.querySelector(".show2 .fa-eye");
    var eyeSlash = document.querySelector(".show2 .fa-eye-slash");
    if (pswInput2.type === "password") {
        pswInput2.type = "text"
        eye.style.opacity = "0"
        eyeSlash.style.opacity = "1"

    } else {
        pswInput2.type = "password"
        eye.style.opacity = "1"
        eyeSlash.style.opacity = "0"
    }
}

// product detail show
var desc = document.querySelector(".desc");
var desc2 = document.querySelector(".desc2");
var text = document.querySelector(".text");
var about = document.querySelector(".aboutProduct");
var about2 = document.querySelector(".aboutProduct2");
var main = document.querySelector(".main");
var main2 = document.querySelector(".main2");

var page = document.querySelector("#singleProduct");


if (desc != null) {
    desc.addEventListener("click", function () {
        text.style.opacity = "1";
        about.style.opacity = "0";
        about2.style.opacity = "0";
        main.style.backgroundColor = "#1d2326";
        main2.style.backgroundColor = "#121618";
        main.style.borderBottomColor = "#1d2326";
        main2.style.borderBottomColor = "#dce4e8";
    })
}

if (desc2 != null) {
    desc2.addEventListener("click", function () {
        about.style.opacity = "1";
        about2.style.opacity = "1";
        text.style.opacity = "0";
        main2.style.backgroundColor = "#1d2326";
        main.style.backgroundColor = "#121618";
        main.style.borderBottom = "2px solid #dce4e8";
        main2.style.borderBottomColor = "#1d2326";
    })
}



//zoom image on mousemove in product detalis page
var image = document.querySelector(".image");
if (image != null) {
    image.addEventListener("mousemove", function (e) {
        var width = image.offsetWidth;
        var height = image.offsetHeight;

        var mouseX = e.offsetX;
        var mouseY = e.offsetY;

        var bgPosX = (mouseX / width * 100);
        var bgPosY = (mouseY / height * 100);

        image.style.backgroundPosition = bgPosX + "%" + bgPosY + "%";
    })
}











