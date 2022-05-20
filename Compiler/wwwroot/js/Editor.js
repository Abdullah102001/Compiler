
       
            var availableKeywords = ['SIowf', 'Stop', 'SIow', 'Loopwhen', 'Loli', 'Iteratewhen', 'If', 'Else', 'Chain', 'Chilo', 'Iow', 'Include', 'Iowf',
                'Worthless', 'Turnback', "$$$", "/$ $/", "Then"];
            function split(val) {
                return val.split(/( |\n)/)
            }
            function extractLast(term) {
                return split(term).pop();
            }

            $("#codeEditor")
                // don't navigate away from the field on tab when selecting an item
                .on("keydown", function (event) {
                    if (event.keyCode === $.ui.keyCode.TAB &&
                        $(this).autocomplete("instance").menu.active) {
                        event.preventDefault();
                    }
                })
                .autocomplete({
                    minLength: 1,
                    source: function (request, response) {
                        // delegate back to autocomplete, but extract the last term
                        response($.ui.autocomplete.filter(
                            availableKeywords, extractLast(request.term)));
                    },
                    focus: function () {
                        // prevent value inserted on focus
                        return false;
                    },
                    select: function (event, ui) {

                        var terms = split(this.value);
                        // remove the current input
                        terms.pop();
                        // add the selected item

                        terms.push(ui.item.value);

                        terms.push("");

                        this.value = terms.join("");


                        return false;
                    }
                });
            var Tokens;
            $("#browse").click(function () {
                $(this).data('clicked', true);
                $("#BrowseFile").on('change', function () {
                    var files = document.getElementById('BrowseFile').files;
                    if (files.length > 0) {
                        if (window.FormData !== undefined) {
                            var mydata = new FormData();
                            for (var x = 0; x < files.length; x++) {
                                mydata.append("file" + x, files[x]);

                            }
                            document.getElementById("codeEditor").value = "";
                            $.ajax({
                                type: "POST",
                                url: "/Home/ReadFile",
                                contentType: false,
                                processData: false,
                                data: mydata,

                                success: function (result) {

                                    Tokens = result;
                                    

                                }

                            })
                        }
                       
                    }
                });
                
            });



            $("#ScanData").click(function () {
                $(this).data('clicked', true);
                var myData = "";
                if (document.getElementById("codeEditor").value.length != 0 || $("#browse").data('clicked')) {
                    
                     if (document.getElementById("codeEditor").value.length != 0) {
                        myData = document.getElementById("codeEditor").value;
                        
                    }
                   else if ($("#browse").data('clicked')) {
                        myData = Tokens;
                    }
                  

                    $.ajax({
                        type: "POST",
                        url: "/Home/Scanner",
                        data: { str: myData },

                        success: function (result) {
                            $("#OutScan").empty();
                            $("#OutScan").append(result);
                        }

                    })
                }
                else {
                    alert("Enter Your Code!");
                }
            });
            $("#ParseData").click(function () {
                $(this).data('clicked', true);
                var myData = "";
                if (document.getElementById("codeEditor").value.length != 0 || $("#browse").data('clicked')) {
                    
                     if (document.getElementById("codeEditor").value.length != 0) {
                        myData = document.getElementById("codeEditor").value;
                       
                    }
                    else if ($("#browse").data('clicked')) {
                        myData = Tokens;

                    }
                    $.ajax({
                        type: "POST",
                        url: "/Home/Parser",
                        data: { str: myData },

                        success: function (result) {
                            $("#OutParse").empty();
                            $("#OutParse").append(result);
                          

                        }

                    })
                }
                else {
                    alert("Enter Your Code!");
                }
               
            });
           


          

            var htmlTemplateStr = ""

            var codeEditor = document.getElementById('codeEditor');
            var lineCounter = document.getElementById('lineCounter');
            var lineCountCache = 0;
            function line_counter() {
                var lineCount = codeEditor.value.split('\n').length;
                var outarr = new Array();
                if (lineCountCache != lineCount) {
                    for (var x = 0; x < lineCount; x++) {
                        outarr[x] = (x + 1);
                    }
                    lineCounter.value = outarr.join('\n');
                }
                lineCountCache = lineCount;
            }



            codeEditor.addEventListener('scroll', () => {
                lineCounter.scrollTop = codeEditor.scrollTop;
                lineCounter.scrollLeft = codeEditor.scrollLeft;
            });



            codeEditor.addEventListener('input', () => {
                line_counter();
            });

            codeEditor.value = htmlTemplateStr;
            line_counter();

            //Commment and Uncomment
            $("#CommentBtn").click(function () {
                var $txt = jQuery("#codeEditor");
                var startpos = $txt[0].selectionStart;
                var endpos = $txt[0].selectionEnd;
                var textAreaTxt = $txt.val();
                $txt.val(textAreaTxt.substring(0, startpos) + " /$ " + textAreaTxt.substring(startpos, endpos) + " $/ " + textAreaTxt.substring(endpos));
            })

            $("#UncommentBtn").click(function () {
                var $txt = jQuery("#codeEditor");
                var startpos = $txt[0].selectionStart;
                var endpos = $txt[0].selectionEnd;
                var textAreaTxt = $txt.val();
                var selectedText = textAreaTxt.substring(startpos, endpos);
                if (selectedText.includes("/$") && selectedText.includes("$/")) {
                    var modifiedTxt = selectedText.replace("/$", "").replace("$/", "");
                    $txt.val(textAreaTxt.substring(0, startpos) + modifiedTxt + textAreaTxt.substring(endpos));
                }
            })