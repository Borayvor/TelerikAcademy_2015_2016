$(() => { // on document ready
  const GLYPH_UP = 'glyphicon-chevron-up',
    GLYPH_DOWN = 'glyphicon-chevron-down',
    root = $('#root'),
    navbar = root.find('nav.navbar'),
    mainNav = navbar.find('#main-nav'),
    contentContainer = $('#root #content'),
    loginForm = $('#login'),
    logoutForm = $('#logout'),
    usernameSpan = $('#span-username'),
    usernameInput = $('#login input'),
    alertTemplate = $($('#alert-template').text());

  (function checkForLoggedUser() {
    data.users.current()
      .then((user) => {
        if (user) {
          usernameSpan.text(user);
          loginForm.addClass('hidden');
          logoutForm.removeClass('hidden');
        }
      });
  })();

  function showMsg(msg, type, cssClass, delay) {
    let container = alertTemplate.clone(true)
      .addClass(cssClass).text(`${type}: ${msg}`)
      .appendTo(root);

    setTimeout(() => {
      container.remove();
    }, delay || 2000);
  }

  // start threads
  function loadThreadsContent(threads) {
    let container = $($('#threads-container-template').text()),
      threadsContainer = container.find('#threads');

    function getAddNewThreadUI() {
      let template = $($('#thread-new-template').html());
      return template.clone(true);
    }

    threads.forEach((th) => {
      let currentThreadUI = _getThreadUI(th.title, th.id, th.user, th.postDate);
      threadsContainer.append(currentThreadUI);
    });

    threadsContainer.append(getAddNewThreadUI());

    contentContainer.find('#container-thraeds').remove();
    contentContainer.html('').prepend(container);
  }

  function loadMessagesContent(data) {
    let container = $($('#messages-container-template').text()),
      messagesContainer = container.find('.panel-body');
    container.attr('data-thread-id', data.result.id);

    function getAddNewMsgUI() {
      let template = $($('#message-new-template').html());
      return template.clone(true);
    }

    if (data.result.messages && data.result.messages.length > 0) {
      data.result.messages.forEach((msg) => {
        messagesContainer.append(_getMsgUI(msg.content, msg.user, msg.postDate));
      });
    } else {
      messagesContainer.append(_getMsgUI('No messages!'));
    }

    messagesContainer.append(getAddNewMsgUI());

    container.find('.thread-title').text(data.result.title);
    contentContainer.append(container);
  }

  function loadGalleryContent(data) {
    let list = data.data.children,
      containerGallery = $($('#gallery-container-tempalte').text()),
      containerImgs = containerGallery.find('#gallery-imgs'),
      item = $($('#gallery-img-tempalte').text()),
      itemImg = item.find('img.gallery-item-img'),
      itemTitle = item.find('.gallery-item-title');

    list.forEach((el) => {
      itemTitle.text(el.data.title);
      itemImg.attr('src', el.data.thumbnail);

      containerImgs.append(item.clone(true));
    });

    contentContainer.html('').append(containerGallery);
  }

  function addThreadToUI(data) {    
      let th = data.result;
      let currentThreadUI = _getThreadUI(th.title, th.id, th.user, th.postDate);
      $('#input-add-thread').val('');
      $('.new-thread-add').before(currentThreadUI);

      showMsg('Successfuly added the new thread', 'Success', 'alert-success');
  }

  function addMessageToUI(data) {
    let container = $('.container-messages');
    container.attr('data-thread-id', data.id);

    container.find('.input-add-message').val('');

    let currentMessageUI;

    if (data.messages && data.messages.length > 0) {
      let msg = data.messages[data.messages.length - 1];

      if (msg.content.length === 0) {
        msg.content = 'No messages!';
      }

      currentMessageUI = _getMsgUI(msg.content, msg.user, msg.postDate);
    }

    container.find('.new-message-add').before(currentMessageUI);

    showMsg('Successfuly added the new mssagee', 'Success', 'alert-success')
  }

  function _getThreadUI(title, id, creator, date) {
    if (date) {
      date = _formatDate(date);
    }

    let template = $($('#thread-template').text()).attr('data-id', id),
      threadTitle = template.find('.thread-title').text(title),
      threadCreator = template.find('.thread-creator').text(creator || 'anonymous'),
      threadDate = template.find('.thread-date').text(date || 'unknown');

    return template.clone(true);
  }

  function _getMsgUI(msg, author, date) {
    if (date) {
      date = _formatDate(date);
    }

    let template = $($('#messages-template').text());
    template.find('.message-content').text(msg);
    template.find('.message-creator').text(author || 'anonymous');
    template.find('.message-date').text(date || 'unknown');

    return template.clone(true);
  }

  function _formatDate(date) {
    var monthNames = [
      "January", "February", "March",
      "April", "May", "June", "July",
      "August", "September", "October",
      "November", "December"
    ];

    var newDate = new Date();
    var day = newDate.getDate();
    var monthIndex = newDate.getMonth();
    var year = newDate.getFullYear();

    return day + '-' + monthNames[monthIndex] + '-' + year;
  }

  navbar.on('click', 'li', (ev) => {
    let $target = $(ev.target);
    $target.parents('nav').find('li').removeClass('active');
    $target.parents('li').addClass('active');
  });

  navbar.on('click', '#btn-threads', (ev) => {
    data.threads.get()
      .then((data) => {
        loadThreadsContent(data.result);
      });
  });

  contentContainer.on('click', '#btn-add-thread', (ev) => {
    let title = $(ev.target).parents('form').find('input#input-add-thread').val() || null;
    data.threads.add(title)
      .then(addThreadToUI)
      .catch((err) => showMsg(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));
  });

  contentContainer.on('click', 'a.thread-title', (ev) => {
    let $target = $(ev.target),
      threadId = $target.parents('.thread').attr('data-id');

    data.threads.getById(threadId)
      .then(loadMessagesContent)
      .catch((err) => showMsg(err, 'Error', 'alert-danger'));
  });

  contentContainer.on('click', '.btn-add-message', (ev) => {
    let $target = $(ev.target),
      $container = $target.parents('.container-messages'),
      thId = $container.attr('data-thread-id'),
      msg = $container.find('.input-add-message').val();

    data.threads.addMessage(thId, msg)
      .then(addMessageToUI)
      .catch((err) => showMsg(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));
  });

  contentContainer.on('click', '.btn-close-msg', (ev) => {
    let msgContainer = $(ev.target).parents('.container-messages').remove();
  });

  contentContainer.on('click', '.btn-collapse-msg', (ev) => {
    let $target = $(ev.target);
    if ($target.hasClass(GLYPH_UP)) {
      $target.removeClass(GLYPH_UP).addClass(GLYPH_DOWN);
    } else {
      $target.removeClass(GLYPH_DOWN).addClass(GLYPH_UP);
    }

    $target.parents('.container-messages').find('.messages').toggle();
  });
  // end threads

  // start gallery
  navbar.on('click', '#btn-gallery', (ev) => {
    data.gallery.get()
      .then(loadGalleryContent)
      .catch(console.log);
  });
  // end gallery

  // start login/logout
  navbar.on('click', '#btn-login', (ev) => {
    let username = usernameInput.val() || 'anonymous';
    data.users.login(username)
      .then((user) => {
        usernameInput.val('');
        usernameSpan.text(user);
        loginForm.addClass('hidden');
        logoutForm.removeClass('hidden');
      });
  });
  navbar.on('click', '#btn-logout', (ev) => {
    data.users.logout()
      .then(() => {
        usernameSpan.text('');
        loginForm.removeClass('hidden');
        logoutForm.addClass('hidden');
      });
  });
  // end login/logout
});