<Query Kind="Statements">
  <GACReference>System.Reactive, Version=1.0.2787.104, Culture=neutral, PublicKeyToken=31bf3856ad364e35</GACReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Drawing</Namespace>
</Query>

var urls = new List<string>{
	"http://farm5.static.flickr.com/4037/4337491983_23f99f251c_o.jpg",
	"http://farm5.static.flickr.com/4021/4337490067_cc86d43978_o.jpg",
	"http://farm5.static.flickr.com/4052/4337488241_eb7cf71d66_o.jpg",
	"http://farm3.static.flickr.com/2735/4338230140_e440e5748e_o.jpg",
	"http://farm5.static.flickr.com/4003/4338228500_009e5d5a82_o.jpg",
};

List<WaitHandle> waits = new List<WaitHandle>();
List<Image> images = new List<Image>();
var total = Stopwatch.StartNew();

foreach(var url in urls)
{
	var individual = Stopwatch.StartNew();
	var reset = new ManualResetEvent(false);
	waits.Add(reset);
	
	var req = WebRequest.Create(url);
	
	AsyncCallback callback = ar => {
		var response = req.EndGetResponse(ar);
		
		using(var stream = response.GetResponseStream())
		{
			images.Add(Image.FromStream(stream));
		}
		response.Close();
		
		individual.Stop();
		individual.Elapsed.TotalSeconds.Dump("Individual");
		reset.Set();
	};
	
	req.BeginGetResponse(callback, null);
}

WaitHandle.WaitAll(waits.ToArray());

total.Stop();
total.Elapsed.TotalSeconds.Dump("TOTAL");

images.Dump();