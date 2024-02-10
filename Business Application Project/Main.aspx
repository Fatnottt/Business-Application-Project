<%@ Page Title="" Language="C#" MasterPageFile="~/WithNavbar.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Business_Application_Project.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body data-aos-easing="ease-in-out" data-aos-duration="1000" data-aos-delay="0">
        <section id="hero" class="hero">
            <div class="container position-relative">
                <div class="row gy-5 aos-init aos-animate" data-aos="fade-in">
                    <div class="col-lg-6 order-2 order-lg-1 d-flex flex-column justify-content-center text-center text-lg-start">
                        <h2>Welcome to <span>Bikie</span></h2>
                        <p>Bike Rental, made easy </p>
                        <div class="d-flex justify-content-center justify-content-lg-start">
                            <a href="SignUp.aspx" class="btn-get-started">Sign Up!</a>
                        </div>
                    </div>
                    <div class="col-lg-6 order-1 order-lg-2">
                        <img src="Images\PeopleBike.png" class="img-fluid aos-init aos-animate" alt="" data-aos="zoom-out" data-aos-delay="100">
                    </div>
                </div>
            </div>

            <div class="icon-boxes position-relative">
                <div class="container position-relative">
                    <div class="row gy-3 mt-5">

                        <div class="col-xl-3 col-md-6 aos-init aos-animate" data-aos="fade-up" data-aos-delay="100">
                            <div class="icon-box">
                                <div class="icon"><i class="bi bi-bicycle"></i></div>
                                <h4 class="title text-light">Hassle free rentals.</h4>
                            </div>
                        </div>
                        <!--End Icon Box -->

                        <div class="col-xl-3 col-md-6 aos-init aos-animate" data-aos="fade-up" data-aos-delay="200">
                            <div class="icon-box">
                                <div class="icon"><i class="bi bi-gem"></i></div>
                                <h4 class="title text-light">Rent at your price</h4>
                            </div>
                        </div>
                        <!--End Icon Box -->

                        <div class="col-xl-3 col-md-6 aos-init aos-animate" data-aos="fade-up" data-aos-delay="300">
                            <div class="icon-box">
                                <div class="icon"><i class="bi bi-geo-alt"></i></div>
                                <h4 class="title text-light">Rent anywhere</h4>
                            </div>
                        </div>
                        <!--End Icon Box -->

                        <div class="col-xl-3 col-md-6 aos-init aos-animate" data-aos="fade-up" data-aos-delay="500">
                            <div class="icon-box">
                                <div class="icon"><i class="bi bi-bicycle"></i></div>
                                <h4 class="title text-light">Rent your old bikes</h4>
                            </div>
                        </div>
                        <!--End Icon Box -->

                    </div>
                </div>
            </div>


        </section>
        <!-- End Hero Section -->

        <main id="main">

            <!-- ======= About Us Section ======= -->
            <section id="about" class="about">
                <div class="container aos-init" data-aos="fade-up">

                    <div class="section-header">
                        <h2>About Us</h2>
                        <p>At Biki, we revolutionize the bicycle rental experience, fostering community, sustainability, and seamless convenience in every ride.</p>
                    </div>

                    <div class="row gy-4">
                        <div class="col-lg-6">
                            <h3>Unparalled Experience, Only At Bikie.</h3>
                            <img src="Images/active_bikers_ltr.jpg" class="img-fluid rounded-4 mb-4" alt="">
                            <p><strong>Empowering Communities: </strong>Join Biki's vibrant community and embrace a greener, healthier lifestyle. With our peer-to-peer model, every bike rental becomes a step towards sustainability. Connect with fellow cyclists, share experiences, and shape a brighter future together. Biki – more than just bikes, it's a community-driven movement.</p>
                            <p><strong>Unparalleled Assurance: </strong>Choose Biki for unparalleled peace of mind. With transparent policies and robust security measures, your rental experience is guaranteed to be smooth and secure. Trust Biki for reliability and satisfaction at every turn.</p>
                        </div>
                        <div class="col-lg-6">
                            <div class="content ps-0 ps-lg-5">
                                <p class="fst-italic">
                                    At Bikie, we strive to achieve the best for our customers. As such we have 3 guarantees that we promise to uphold.
                                </p>
                                <ul>
                                    <li><i class="bi bi-check-circle-fill"></i>Seamless rentals, every time.</li>
                                    <li><i class="bi bi-check-circle-fill"></i>Unmatched variety, tailored to you.</li>
                                    <li><i class="bi bi-check-circle-fill"></i>Security and satisfaction, guaranteed.</li>
                                </ul>
                                <p>
                                    <strong>Elevate Your Ride: </strong>Biki reimagines bike rentals with a seamless, intuitive platform. Find your perfect ride effortlessly and explore a diverse range of bicycles tailored to your preferences. Elevate your ride with Biki – where convenience, variety, and excellence converge for an unforgettable cycling experience.
                                </p>

                                <div class="position-relative mt-4">
                                    <img src="Images/active_bikers_rtl.jpg" class="img-fluid rounded-4" alt="">
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </section>
            <!-- End About Us Section -->

            <!-- ======= Call To Action Section ======= -->
            <section id="call-to-action" class="call-to-action">
                <div class="container text-center aos-init" data-aos="zoom-out">
                    <a href="https://www.youtube.com/watch?v=_W1fmntUMos" class="glightbox play-btn"></a>
                    <h3>Rent With Bikie</h3>
                    <p>Rent, lend, whatever you want to do with your Bike</p>
                    <a class="cta-btn" href="#">Rent With Bikie</a>
                </div>
            </section>
            <!-- End Call To Action Section -->

            <!-- ======= Testimonials Section ======= -->
            <section id="testimonials" class="testimonials">
                <div class="container aos-init" data-aos="fade-up">

                    <div class="section-header">
                        <h2>Testimonials</h2>
                        <p>Here's what our customers have to say about us.</p>
                    </div>

                    <div class="slides-3 swiper swiper-initialized swiper-horizontal swiper-pointer-events aos-init" data-aos="fade-up" data-aos-delay="100">
                        <div class="swiper-wrapper" id="swiper-wrapper-377c185cf2fa231010" aria-live="off" style="transform: translate3d(-2232px, 0px, 0px); transition-duration: 0ms;">
                            <div class="swiper-slide swiper-slide-duplicate swiper-slide-duplicate-prev" data-swiper-slide-index="2" role="group" aria-label="3 / 5" style="width: 372px;">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <div class="d-flex align-items-center">
                                            <img src="assets/img/testimonials/testimonials-3.jpg" class="testimonial-img flex-shrink-0" alt="">
                                            <div>
                                                <h3>Jena Karlis</h3>
                                                <h4>Store Owner</h4>
                                                <div class="stars">
                                                    <i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <p>
                                            <i class="bi bi-quote quote-icon-left"></i>
                                            Enim nisi quem export duis labore cillum quae magna enim sint quorum nulla quem veniam duis minim tempor labore quem eram duis noster aute amet eram fore quis sint minim.
                    <i class="bi bi-quote quote-icon-right"></i>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="swiper-slide swiper-slide-duplicate swiper-slide-duplicate-active" data-swiper-slide-index="3" role="group" aria-label="4 / 5" style="width: 372px;">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <div class="d-flex align-items-center">
                                            <img src="assets/img/testimonials/testimonials-4.jpg" class="testimonial-img flex-shrink-0" alt="">
                                            <div>
                                                <h3>Matt Brandon</h3>
                                                <h4>Freelancer</h4>
                                                <div class="stars">
                                                    <i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <p>
                                            <i class="bi bi-quote quote-icon-left"></i>
                                            Fugiat enim eram quae cillum dolore dolor amet nulla culpa multos export minim fugiat minim velit minim dolor enim duis veniam ipsum anim magna sunt elit fore quem dolore.
                    <i class="bi bi-quote quote-icon-right"></i>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="swiper-slide swiper-slide-duplicate swiper-slide-duplicate-next" data-swiper-slide-index="4" role="group" aria-label="5 / 5" style="width: 372px;">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <div class="d-flex align-items-center">
                                            <img src="assets/img/testimonials/testimonials-5.jpg" class="testimonial-img flex-shrink-0" alt="">
                                            <div>
                                                <h3>John Larson</h3>
                                                <h4>Entrepreneur</h4>
                                                <div class="stars">
                                                    <i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <p>
                                            <i class="bi bi-quote quote-icon-left"></i>
                                            Quis quorum aliqua sint quem legam fore sunt eram irure aliqua veniam tempor noster veniam enim culpa labore duis sunt culpa nulla illum cillum fugiat legam esse veniam culpa fore.
                    <i class="bi bi-quote quote-icon-right"></i>
                                        </p>
                                    </div>
                                </div>
                            </div>

                            <div class="swiper-slide" data-swiper-slide-index="0" role="group" aria-label="1 / 5" style="width: 372px;">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <div class="d-flex align-items-center">
                                            <img src="assets/img/testimonials/testimonials-1.jpg" class="testimonial-img flex-shrink-0" alt="">
                                            <div>
                                                <h3>Saul Goodman</h3>
                                                <h4>Ceo &amp; Founder</h4>
                                                <div class="stars">
                                                    <i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <p>
                                            <i class="bi bi-quote quote-icon-left"></i>
                                            Proin iaculis purus consequat sem cure digni ssim donec porttitora entum suscipit rhoncus. Accusantium quam, ultricies eget id, aliquam eget nibh et. Maecen aliquam, risus at semper.
                    <i class="bi bi-quote quote-icon-right"></i>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- End testimonial item -->

                            <div class="swiper-slide" data-swiper-slide-index="1" role="group" aria-label="2 / 5" style="width: 372px;">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <div class="d-flex align-items-center">
                                            <img src="assets/img/testimonials/testimonials-2.jpg" class="testimonial-img flex-shrink-0" alt="">
                                            <div>
                                                <h3>Sara Wilsson</h3>
                                                <h4>Designer</h4>
                                                <div class="stars">
                                                    <i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <p>
                                            <i class="bi bi-quote quote-icon-left"></i>
                                            Export tempor illum tamen malis malis eram quae irure esse labore quem cillum quid cillum eram malis quorum velit fore eram velit sunt aliqua noster fugiat irure amet legam anim culpa.
                    <i class="bi bi-quote quote-icon-right"></i>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- End testimonial item -->

                            <div class="swiper-slide swiper-slide-prev" data-swiper-slide-index="2" role="group" aria-label="3 / 5" style="width: 372px;">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <div class="d-flex align-items-center">
                                            <img src="assets/img/testimonials/testimonials-3.jpg" class="testimonial-img flex-shrink-0" alt="">
                                            <div>
                                                <h3>Jena Karlis</h3>
                                                <h4>Store Owner</h4>
                                                <div class="stars">
                                                    <i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <p>
                                            <i class="bi bi-quote quote-icon-left"></i>
                                            Enim nisi quem export duis labore cillum quae magna enim sint quorum nulla quem veniam duis minim tempor labore quem eram duis noster aute amet eram fore quis sint minim.
                    <i class="bi bi-quote quote-icon-right"></i>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- End testimonial item -->

                            <div class="swiper-slide swiper-slide-active" data-swiper-slide-index="3" role="group" aria-label="4 / 5" style="width: 372px;">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <div class="d-flex align-items-center">
                                            <img src="assets/img/testimonials/testimonials-4.jpg" class="testimonial-img flex-shrink-0" alt="">
                                            <div>
                                                <h3>Matt Brandon</h3>
                                                <h4>Freelancer</h4>
                                                <div class="stars">
                                                    <i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <p>
                                            <i class="bi bi-quote quote-icon-left"></i>
                                            Fugiat enim eram quae cillum dolore dolor amet nulla culpa multos export minim fugiat minim velit minim dolor enim duis veniam ipsum anim magna sunt elit fore quem dolore.
                    <i class="bi bi-quote quote-icon-right"></i>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- End testimonial item -->

                            <div class="swiper-slide swiper-slide-next" data-swiper-slide-index="4" role="group" aria-label="5 / 5" style="width: 372px;">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <div class="d-flex align-items-center">
                                            <img src="assets/img/testimonials/testimonials-5.jpg" class="testimonial-img flex-shrink-0" alt="">
                                            <div>
                                                <h3>John Larson</h3>
                                                <h4>Entrepreneur</h4>
                                                <div class="stars">
                                                    <i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <p>
                                            <i class="bi bi-quote quote-icon-left"></i>
                                            Quis quorum aliqua sint quem legam fore sunt eram irure aliqua veniam tempor noster veniam enim culpa labore duis sunt culpa nulla illum cillum fugiat legam esse veniam culpa fore.
                    <i class="bi bi-quote quote-icon-right"></i>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- End testimonial item -->

                            <div class="swiper-slide swiper-slide-duplicate" data-swiper-slide-index="0" role="group" aria-label="1 / 5" style="width: 372px;">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <div class="d-flex align-items-center">
                                            <img src="assets/img/testimonials/testimonials-1.jpg" class="testimonial-img flex-shrink-0" alt="">
                                            <div>
                                                <h3>Saul Goodman</h3>
                                                <h4>Ceo &amp; Founder</h4>
                                                <div class="stars">
                                                    <i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <p>
                                            <i class="bi bi-quote quote-icon-left"></i>
                                            Proin iaculis purus consequat sem cure digni ssim donec porttitora entum suscipit rhoncus. Accusantium quam, ultricies eget id, aliquam eget nibh et. Maecen aliquam, risus at semper.
                    <i class="bi bi-quote quote-icon-right"></i>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="swiper-slide swiper-slide-duplicate" data-swiper-slide-index="1" role="group" aria-label="2 / 5" style="width: 372px;">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <div class="d-flex align-items-center">
                                            <img src="assets/img/testimonials/testimonials-2.jpg" class="testimonial-img flex-shrink-0" alt="">
                                            <div>
                                                <h3>Sara Wilsson</h3>
                                                <h4>Designer</h4>
                                                <div class="stars">
                                                    <i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <p>
                                            <i class="bi bi-quote quote-icon-left"></i>
                                            Export tempor illum tamen malis malis eram quae irure esse labore quem cillum quid cillum eram malis quorum velit fore eram velit sunt aliqua noster fugiat irure amet legam anim culpa.
                    <i class="bi bi-quote quote-icon-right"></i>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="swiper-slide swiper-slide-duplicate swiper-slide-duplicate-prev" data-swiper-slide-index="2" role="group" aria-label="3 / 5" style="width: 372px;">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <div class="d-flex align-items-center">
                                            <img src="assets/img/testimonials/testimonials-3.jpg" class="testimonial-img flex-shrink-0" alt="">
                                            <div>
                                                <h3>Jena Karlis</h3>
                                                <h4>Store Owner</h4>
                                                <div class="stars">
                                                    <i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <p>
                                            <i class="bi bi-quote quote-icon-left"></i>
                                            Enim nisi quem export duis labore cillum quae magna enim sint quorum nulla quem veniam duis minim tempor labore quem eram duis noster aute amet eram fore quis sint minim.
                    <i class="bi bi-quote quote-icon-right"></i>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="swiper-pagination swiper-pagination-clickable swiper-pagination-bullets swiper-pagination-horizontal"><span class="swiper-pagination-bullet" tabindex="0" role="button" aria-label="Go to slide 1"></span><span class="swiper-pagination-bullet" tabindex="0" role="button" aria-label="Go to slide 2"></span><span class="swiper-pagination-bullet" tabindex="0" role="button" aria-label="Go to slide 3"></span><span class="swiper-pagination-bullet swiper-pagination-bullet-active" tabindex="0" role="button" aria-label="Go to slide 4" aria-current="true"></span><span class="swiper-pagination-bullet" tabindex="0" role="button" aria-label="Go to slide 5"></span></div>
                        <span class="swiper-notification" aria-live="assertive" aria-atomic="true"></span>
                    </div>

                </div>
            </section>
            <!-- End Testimonials Section -->

            <!-- ======= Portfolio Section ======= -->
            <section id="portfolio" class="portfolio sections-bg">
                <div class="container aos-init" data-aos="fade-up">

                    <div class="section-header">
                        <h2>Portfolio</h2>
                        <p>Here's the products we have to offer. Take & Go</p>
                    </div>

                    <div class="portfolio-isotope aos-init" data-portfolio-filter="*" data-portfolio-layout="masonry" data-portfolio-sort="original-order" data-aos="fade-up" data-aos-delay="100">

                        <div>
                            <ul class="portfolio-flters">
                                <li data-filter="*" class="filter-active">All</li>
                                <li data-filter=".filter-app">App</li>
                                <li data-filter=".filter-product">Product</li>
                                <li data-filter=".filter-branding">Branding</li>
                                <li data-filter=".filter-books">Books</li>
                            </ul>
                            <!-- End Portfolio Filters -->
                        </div>

                        <div class="row gy-4 portfolio-container" style="position: relative; height: 1570.38px;">

                            <div class="col-xl-4 col-md-6 portfolio-item filter-app" style="position: absolute; left: 0px; top: 0px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/app-1.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/app-1.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">App 1</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                            <div class="col-xl-4 col-md-6 portfolio-item filter-product" style="position: absolute; left: 380px; top: 0px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/product-1.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/product-1.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">Product 1</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                            <div class="col-xl-4 col-md-6 portfolio-item filter-branding" style="position: absolute; left: 760px; top: 0px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/branding-1.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/branding-1.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">Branding 1</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                            <div class="col-xl-4 col-md-6 portfolio-item filter-books" style="position: absolute; left: 0px; top: 392.594px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/books-1.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/books-1.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">Books 1</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                            <div class="col-xl-4 col-md-6 portfolio-item filter-app" style="position: absolute; left: 380px; top: 392.594px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/app-2.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/app-2.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">App 2</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                            <div class="col-xl-4 col-md-6 portfolio-item filter-product" style="position: absolute; left: 760px; top: 392.594px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/product-2.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/product-2.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">Product 2</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                            <div class="col-xl-4 col-md-6 portfolio-item filter-branding" style="position: absolute; left: 0px; top: 785.188px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/branding-2.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/branding-2.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">Branding 2</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                            <div class="col-xl-4 col-md-6 portfolio-item filter-books" style="position: absolute; left: 380px; top: 785.188px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/books-2.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/books-2.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">Books 2</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                            <div class="col-xl-4 col-md-6 portfolio-item filter-app" style="position: absolute; left: 760px; top: 785.188px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/app-3.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/app-3.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">App 3</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                            <div class="col-xl-4 col-md-6 portfolio-item filter-product" style="position: absolute; left: 0px; top: 1177.78px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/product-3.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/product-3.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">Product 3</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                            <div class="col-xl-4 col-md-6 portfolio-item filter-branding" style="position: absolute; left: 380px; top: 1177.78px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/branding-3.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/branding-3.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">Branding 3</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                            <div class="col-xl-4 col-md-6 portfolio-item filter-books" style="position: absolute; left: 760px; top: 1177.78px;">
                                <div class="portfolio-wrap">
                                    <a href="assets/img/portfolio/books-3.jpg" data-gallery="portfolio-gallery-app" class="glightbox">
                                        <img src="assets/img/portfolio/books-3.jpg" class="img-fluid" alt=""></a>
                                    <div class="portfolio-info">
                                        <h4><a href="portfolio-details.html" title="More Details">Books 3</a></h4>
                                        <p>Lorem ipsum, dolor sit amet consectetur</p>
                                    </div>
                                </div>
                            </div>
                            <!-- End Portfolio Item -->

                        </div>
                        <!-- End Portfolio Container -->

                    </div>

                </div>
            </section>
            <!-- End Portfolio Section -->

            <!-- ======= Frequently Asked Questions Section ======= -->
            <section id="faq" class="faq">
                <div class="container aos-init" data-aos="fade-up">

                    <div class="row gy-4">

                        <div class="col-lg-4">
                            <div class="content px-xl-5">
                                <h3>Frequently Asked <strong>Questions</strong></h3>
                                <p>
                                    You have bikes, we have answers. Here are some of the most frequently asked questions about Bikie.
                                </p>
                            </div>
                        </div>

                        <div class="col-lg-8">

                            <div class="accordion accordion-flush aos-init" id="faqlist" data-aos="fade-up" data-aos-delay="100">

                                <div class="accordion-item">
                                    <h3 class="accordion-header">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#faq-content-1">
                                            <span class="num">1.</span>
                                            How does Biki ensure the safety and condition of the bicycles available for rent?
                                        </button>
                                    </h3>
                                    <div id="faq-content-1" class="accordion-collapse collapse" data-bs-parent="#faqlist">
                                        <div class="accordion-body">
                                            At Biki, we prioritize safety and quality. Each bicycle listed on our platform undergoes a thorough verification process before being made available for rent. Additionally, renters are required to provide a refundable security deposit, ensuring accountability and encouraging responsible usage. Our platform also features a robust review system, allowing users to provide feedback on their rental experience, ensuring a trustworthy environment for all.                                       
                                        </div>
                                    </div>
                                </div>
                                <!-- # Faq item-->

                                <div class="accordion-item">
                                    <h3 class="accordion-header">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#faq-content-2">
                                            <span class="num">2.</span>
                                            What happens if I encounter an issue with the bicycle during my rental period?
                                        </button>
                                    </h3>
                                    <div id="faq-content-2" class="accordion-collapse collapse" data-bs-parent="#faqlist">
                                        <div class="accordion-body">
                                            We understand that unforeseen issues may arise. If you encounter any problems with the bicycle during your rental period, simply reach out to our dedicated customer support team. We're here to assist you every step of the way, ensuring a seamless rental experience. Your satisfaction is our priority.
                                        </div>
                                    </div>
                                </div>
                                <!-- # Faq item-->

                                <div class="accordion-item">
                                    <h3 class="accordion-header">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#faq-content-3">
                                            <span class="num">3.</span>
                                            Can I rent a bicycle for an extended period of time, such as a week or more?
                                        </button>
                                    </h3>
                                    <div id="faq-content-3" class="accordion-collapse collapse" data-bs-parent="#faqlist">
                                        <div class="accordion-body">
                                            Absolutely! Biki offers flexible rental options to accommodate your needs. Whether you need a bicycle for a few hours or an extended period, our platform allows you to choose the rental duration that suits you best. Simply select your desired rental period during the booking process, and you're all set to explore the city on two wheels.

                                        </div>
                                    </div>
                                </div>
                                <!-- # Faq item-->

                                <div class="accordion-item">
                                    <h3 class="accordion-header">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#faq-content-4">
                                            <span class="num">4.</span>
                                            How does Biki ensure fair pricing for both bicycle owners and renters?
                                        </button>
                                    </h3>
                                    <div id="faq-content-4" class="accordion-collapse collapse" data-bs-parent="#faqlist">
                                        <div class="accordion-body">
                                            Transparency and fairness are core principles at Biki. Bicycle owners have the flexibility to set their own rental prices based on factors such as bike type, duration, and additional features. For renters, our platform provides visibility into pricing options, allowing you to choose the rental option that fits your budget. We believe in empowering both owners and renters to find mutually beneficial arrangements.
                                        </div>
                                    </div>
                                </div>
                                <!-- # Faq item-->

                                <div class="accordion-item">
                                    <h3 class="accordion-header">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#faq-content-5">
                                            <span class="num">5.</span>
                                            What measures does Biki take to protect user privacy and data security?
                                        </button>
                                    </h3>
                                    <div id="faq-content-5" class="accordion-collapse collapse" data-bs-parent="#faqlist">
                                        <div class="accordion-body">
                                            At Biki, we take the privacy and security of our users' data seriously. Our platform employs advanced encryption and security protocols to safeguard your personal information. We adhere to strict privacy policies and comply with industry standards to ensure the confidentiality of your data. Your trust is invaluable to us, and we're committed to maintaining the highest standards of data protection.

                                        </div>
                                    </div>
                                </div>
                                <!-- # Faq item-->

                            </div>

                        </div>
                    </div>

                </div>
            </section>
            <!-- End Frequently Asked Questions Section -->
        </main>
        <!-- End #main -->

        <!-- ======= Footer ======= -->
        <footer id="footer" class="footer">

            <div class="container">
                <div class="row gy-4">
                    <div class="col-lg-5 col-md-12 footer-info">
                        <a href="index.html" class="logo d-flex align-items-center">
                            <span>Bikie</span>
                        </a>
                        <p>At Biki, we're not just revolutionizing the way you rent bicycles - we're transforming the way you experience urban mobility. With innovation at our core and a commitment to excellence, we're empowering you to explore the world on two wheels like never before. Ride with confidence, ride with convenience, ride with Biki.</p>
                    </div>

                    <div class="col-lg-2 col-6 footer-links">
                    </div>

                    <div class="col-lg-2 col-6 footer-links">
                    </div>

                    <div class="col-lg-3 col-md-12 footer-contact text-center text-md-start">
                        <h4>Contact Us</h4>
                        <p>
                            180 Ang Mo Kio Avenue 8 
                            <br>
                            Singapore, 569830<br>
                            Nanyang Polytechnic
                            <br>
                            <br>
                            <strong>Phone:</strong> +65 12345678<br>
                            <strong>Email:</strong> yatsleo@gmail.com<br>
                        </p>

                    </div>

                </div>
            </div>

            <div class="container mt-4">
                <div class="copyright">
                    © Copyright <strong><span>Impact</span></strong>. All Rights Reserved
                </div>
            </div>

        </footer>
        <!-- End Footer -->
        <asp:Label ID="UserInfoLabel" runat="server" Text=""></asp:Label>

        <a href="#" class="scroll-top d-flex align-items-center justify-content-center"><i class="bi bi-arrow-up-short"></i></a>


    </body>
</asp:Content>
