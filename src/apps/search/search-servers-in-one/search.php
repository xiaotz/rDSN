<?php 
$_PROG = new t_program("search");

$_PROG->namespaces["cpp"] = "dsn.app.search";
$_PROG->namespaces["csharp"] = "dsn.app.search";

$tmp = new t_struct($_PROG, "StringQuery");
$tmp->add_field("Query", "string");

$tmp = new t_struct($_PROG, "ErrorResult");
$tmp->add_field("ErrorCode", "i32");

$tmp = new t_struct($_PROG, "Rank");
$tmp->add_field("Value", "i32");

$tmp = new t_struct($_PROG, "AlterativeQueryList");
$tmp->add_field("RawQuery", "search.StringQuery");
$tmp->add_field("Alterations", "vector< search.StringQuery>");

$tmp = new t_struct($_PROG, "AugmentedQuery");
$tmp->add_field("QueryId", "i32");
$tmp->add_field("RawQuery", "search.StringQuery");
$tmp->add_field("AlteredQuery", "search.StringQuery");
$tmp->add_field("TopX", "i32");

$tmp = new t_struct($_PROG, "DocId");
$tmp->add_field("URL", "string");

$tmp = new t_struct($_PROG, "DocPosition");
$tmp->add_field("DocIdentity", "search.DocId");
$tmp->add_field("Position", "i32");

$tmp = new t_struct($_PROG, "PerDocStaticRank");
$tmp->add_field("Pos", "search.DocPosition");
$tmp->add_field("StaticRank", "i32");

$tmp = new t_struct($_PROG, "StaticRankResult");
$tmp->add_field("Query", "search.AugmentedQuery");
$tmp->add_field("Results", "vector< search.PerDocStaticRank>");

$tmp = new t_struct($_PROG, "PerDocRank");
$tmp->add_field("Id", "search.DocId");
$tmp->add_field("RankValue", "search.Rank");

$tmp = new t_struct($_PROG, "Caption");
$tmp->add_field("DocIdentifier", "search.DocId");
$tmp->add_field("Title", "string");
$tmp->add_field("CaptionHtml", "string");

$tmp = new t_struct($_PROG, "QueryResult");
$tmp->add_field("RawQuery", "search.StringQuery");
$tmp->add_field("Query", "search.AugmentedQuery");
$tmp->add_field("Results", "vector< search.Caption>");

$tmp = new t_service($_PROG, "IFEX");
$tmp2 = $tmp->add_function("search.StringQuery", "OnSearchQuery");
$tmp2->add_param("query", "search.StringQuery");

$tmp = new t_service($_PROG, "ALTA");

$tmp = new t_service($_PROG, "IsCache");
$tmp2 = $tmp->add_function("search.QueryResult", "Get");
$tmp2->add_param("query", "search.StringQuery");
$tmp2 = $tmp->add_function("search.ErrorResult", "Put");
$tmp2->add_param("result", "search.QueryResult");

$tmp = new t_service($_PROG, "QU");
$tmp2 = $tmp->add_function("search.AlterativeQueryList", "OnQueryUnderstanding");
$tmp2->add_param("query", "search.StringQuery");

$tmp = new t_service($_PROG, "QU2");
$tmp2 = $tmp->add_function("search.AugmentedQuery", "OnQueryAnnotation");
$tmp2->add_param("query", "search.StringQuery");

$tmp = new t_service($_PROG, "TLA");

$tmp = new t_service($_PROG, "WebCache");
$tmp2 = $tmp->add_function("search.QueryResult", "Get");
$tmp2->add_param("query", "search.AugmentedQuery");
$tmp2 = $tmp->add_function("search.ErrorResult", "Put");
$tmp2->add_param("result", "search.QueryResult");

$tmp = new t_service($_PROG, "SaaS");
$tmp2 = $tmp->add_function("search.StaticRankResult", "OnL1Selection");
$tmp2->add_param("query", "search.AugmentedQuery");

$tmp = new t_service($_PROG, "RaaS");
$tmp2 = $tmp->add_function("search.Rank", "OnL2Rank");
$tmp2->add_param("pos", "search.PerDocStaticRank");

$tmp = new t_service($_PROG, "CDG");
$tmp2 = $tmp->add_function("search.Caption", "Get");
$tmp2->add_param("id", "search.DocId");
$tmp2 = $tmp->add_function("search.ErrorResult", "Put");
$tmp2->add_param("caption", "search.Caption");

?>
